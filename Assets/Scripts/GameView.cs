using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameView : MonoBehaviour
{

    public GameObject gameOverUI;
   
    // public GameObject instructionUI;
    public GameObject completedUI;
    public GameManager gm;

    
   void Start()
    {
        completedUI.SetActive(false);
        gameOverUI.SetActive(false);
        // instructionUI.SetActive(true);
    }

    // public void click()
    // {
    //     instructionUI.SetActive(false);
    // }

    public void gameOver()
    {
       
        gameOverUI.SetActive(true);
        gm.gameOver();

    }

   public void levelCompleted()
    {
       
        completedUI.SetActive(true);
      

    }

    public void tryAgain()
    {
        gm.retry();
    }

   

    public void quit()
    {
        gm.quit();
    }
}
