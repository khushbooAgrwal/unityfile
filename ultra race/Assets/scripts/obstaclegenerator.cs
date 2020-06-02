using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstaclegenerator : MonoBehaviour
{
  
    public GameObject[] obstaclecars;
    // Start is called before the first frame update
    void Start()
    {
       InvokeRepeating ("generateobstaclecar",  2f , Random.Range(1f,3f)); 
    }

    // Update is called once per frame
    void Update()
    {
     
    }
    private void generateobstaclecar()
    {
       if(gamemanager.Gamemanager.gamestates == gamemanager.Gamestates.gameplaying){
       float cargenerationpoint = gamemanager.Gamemanager.gameplayrelated.transform.position.y + 33f;
        int randomNum = Random.Range(0,3);
        if(randomNum == 0){
        Instantiate(obstaclecars[Random.Range(0, obstaclecars.Length)],new Vector3(-8.5f,cargenerationpoint,0f),Quaternion.identity);
        }
        else if(randomNum == 1){
          Instantiate(obstaclecars[Random.Range(0, obstaclecars.Length)],new Vector3(0f,cargenerationpoint,0f),Quaternion.identity);  
        }
        else{
          Instantiate(obstaclecars[Random.Range(0, obstaclecars.Length)],new Vector3(8.5f,cargenerationpoint,0f),Quaternion.identity);  
        }
       }
    }
}
