using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstaclecar : MonoBehaviour
{
    public float movespeed = 0f;
    Rigidbody2D carRb;
    // Start is called before the first frame update
    void Start()
    {
        carRb = GetComponent<Rigidbody2D>();
        if(movespeed >0f){
       
        carRb.velocity = transform.up * Time.deltaTime * movespeed ;
        }
    }

    // Update is called once per frame
    /* void Update()
    {
        if(movespeed >0f){
        //transform.Translate(transform.up * Time.deltaTime * movespeed);
        carRb.velocity = transform.up * Time.deltaTime * movespeed ;
        }
    }
*/
}
