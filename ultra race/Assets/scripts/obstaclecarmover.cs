using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstaclecarmover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnTriggerEnter2D(Collider2D other){
      if(other.tag == "obstaclecar"){
         obstaclecar obscar = other.GetComponent<obstaclecar> ();
         giverandomspeed(obscar);
      }

    }
    private void giverandomspeed(obstaclecar _obstacleCar){
        float randomspeed = Random.Range (2f,10f);
        if(_obstacleCar.movespeed == 0f){
             _obstacleCar.movespeed = randomspeed;

        }
       
    }
}
