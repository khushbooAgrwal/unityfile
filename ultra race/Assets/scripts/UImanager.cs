using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UImanager : MonoBehaviour
{
   
    public GameObject gamename;
    public GameObject scoreui;
    public GameObject coinui;
    public GameObject pausebtn;
     public GameObject playbutton;
      public GameObject quitbutton;
      public GameObject restartbutton;
      public GameObject highscoreandcoin;
    public Text scoretext;
     public Text highscoretext;

      public Text totalcoinstext;

    public Text cointext;

      private int scoreint;
      private int coinint;
      private int highscore;
      private int totalcoins;
 
     private void Awake(){
         if(PlayerPrefs.HasKey("highscore")){
             highscore = PlayerPrefs.GetInt("highscore");
         }
         if(PlayerPrefs.HasKey("totalcoins")){
         totalcoins = PlayerPrefs.GetInt("totalcoins");
         }
         highscoretext.text = highscore.ToString();
         totalcoinstext.text = totalcoins.ToString();
          

     }
      private void Start() {
          scoreint =0;
          scoretext.text = scoreint.ToString();
          coinint =0;
          cointext.text = coinint.ToString();
          restartbutton.SetActive(false);
          deactivateui(false);
      }
        public void playgame(){
            gamename.SetActive(false);
            playbutton.SetActive(false);
            quitbutton.SetActive(false);
            highscoreandcoin.SetActive(false);
            deactivateui(true);
            gamemanager.Gamemanager.gamestates = gamemanager.Gamestates.gameplaying;
            StartCoroutine("IncreaseStore");

   }

   public void restartgame(){
        SceneManager.LoadScene(0);
   }
   public void Activaterestart(){
        gamename.SetActive(true);
        restartbutton.SetActive(true);
        quitbutton.SetActive(true);
   }
    public void Quitgame(){

#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
        Application.Quit();
        Debug.Log("Game Quit");
    }
    private void deactivateui( bool isActive){
        scoreui.SetActive(isActive);
        coinui.SetActive(isActive);
        pausebtn.SetActive(isActive);
    }

    public void increasecoin(){
        coinint += 1;
        cointext.text = coinint.ToString();
    }
    public void SaveGameData(){
        if(scoreint > highscore){
            highscore = scoreint;
        }
        totalcoins += coinint;
        PlayerPrefs.SetInt("highscore",highscore);
        PlayerPrefs.SetInt("totalcoins",totalcoins);
    }
    IEnumerator IncreaseStore(){
        yield return new WaitForSeconds(1f);
        while(true){
            if(gamemanager.Gamemanager.gamestates == gamemanager.Gamestates.gameplaying){
             scoreint += 1;
             scoretext.text = scoreint.ToString();
            }
             yield return new WaitForSeconds(0.2f);
        }
    }
}
