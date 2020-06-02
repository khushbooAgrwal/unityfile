using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercar : MonoBehaviour
{
    private bool carChangingLane;
    private bool isplayercargoingleft;
    private bool isplayercarrotating;
    public float movespeed = 1f;

    private float xpos = 0;
    public roads road;
    private float xrotation = 0f;
    public UImanager uImanager;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void stop()
    {
        carChangingLane = false;
        isplayercarrotating = true;
    }
    void startmoveleft()
    {
        carChangingLane = true;
        isplayercargoingleft = true;
        isplayercarrotating = false;
    }
    void startmoveright()
    {
        carChangingLane = true;
        isplayercargoingleft = false;
        isplayercarrotating = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            startmoveleft();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            startmoveright();
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            stop();
        }

        //mobile
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Input.mousePosition;

            if (mousePos.x < Screen.width / 2f)
            {
                startmoveleft();
            }
            if (mousePos.x > Screen.width / 2f)
            {
                startmoveright();
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            stop();
        }
        if (gamemanager.Gamemanager.gamestates == gamemanager.Gamestates.gameplaying)
        {
            changecarlane();
        }
    }
    private void changecarlane()
    {
        if (carChangingLane && !isplayercarrotating)
        {

            if (isplayercargoingleft)
            {
                if (xpos >= -9f)
                {
                    xpos -= Time.deltaTime * movespeed;
                }
                if (xrotation < 10f)
                {
                    xrotation += Time.deltaTime * movespeed * 2f;
                }

            }
            else if (!isplayercargoingleft)
            {
                if (xpos <= 9f)
                {
                    xpos += Time.deltaTime * movespeed;
                }

                if (xrotation > -10f)
                {
                    xrotation -= Time.deltaTime * movespeed * 2f;
                }
            }
            this.transform.position = new Vector3(xpos, transform.position.y, transform.position.z);
            this.transform.rotation = Quaternion.Euler(0f, 0f, xrotation);

        }
        if (isplayercarrotating)
        {
            xrotation = Mathf.Lerp(xrotation, 0f, Time.deltaTime * movespeed * 2f);
            this.transform.position = new Vector3(xpos, transform.position.y, transform.position.z);
            this.transform.rotation = Quaternion.Euler(0f, 0f, xrotation);
            if (xrotation == 0)
            {
                isplayercarrotating = false;
            }
        }


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "obstaclecar")
        {
            Destroy(other.gameObject);
            road.speed = 0f;
            gamemanager.Gamemanager.gamestates = gamemanager.Gamestates.playerDied;
            uImanager.Activaterestart();
            uImanager.SaveGameData();
            this.gameObject.SetActive(false);

        }
        if (other.tag == "coin")
        {
            Destroy(other.gameObject);
            uImanager.increasecoin();
        }
    }

}
