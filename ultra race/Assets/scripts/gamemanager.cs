using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemanager : MonoBehaviour
{
    public static gamemanager Gamemanager;
    public  GameObject gameplayrelated ;
    public  Gamestates gamestates;
    public  float      movespeed = 5f;
    public enum Gamestates
    {
        none,
        mainmenu,
        gameplaying,
        paused,
        playerDied,
        gameOver
    }
    // Start is called before the first frame update
     void Awake() {
        Gamemanager = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveGamePlayObjects();
    }

    private void MoveGamePlayObjects(){
        if(gamestates == Gamestates.gameplaying){
            gameplayrelated.transform.position += Vector3.up * Time.deltaTime *movespeed;
        }
    }
}
