using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coingenerator : MonoBehaviour
{
   public GameObject coinprefab;
   private void Start() {
       generatecoins();
   }
   private void generatecoins(){
       int noofcoins = Random.Range(3,9);
       float ypos = 10;
      for(int i= 0;i<noofcoins; i++){
          
           Transform coin = Instantiate(coinprefab).transform;
           coin.parent =this.transform;
           coin.localPosition = new Vector2(0f,ypos);
           ypos += 3.5f;
      }
   }
}
