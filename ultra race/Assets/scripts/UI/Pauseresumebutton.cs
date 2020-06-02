using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pauseresumebutton : MonoBehaviour
{
    public Sprite pause;
    public Sprite play;
   public void pauseresumeToggle(){

       if(Time.timeScale != 0){
           GetComponent<Image>().sprite = play ;
       Time.timeScale = 0;
       return;
       }
       if(Time.timeScale == 0){
            GetComponent<Image>().sprite = pause ;
           Time.timeScale = 1;
           return;
       }
   }
}
