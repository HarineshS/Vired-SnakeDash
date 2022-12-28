using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 1;
    }

    public void gameOver()
    {
        //Time.timeScale = 0;
    }

    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void playgame()
    {
        SceneManager.LoadScene("Instructions");
    }
    

    public void instructions()
    {
        SceneManager.LoadScene("Instructions mini");
    }
    

    public void levelselect()
    {
        SceneManager.LoadScene("levelselect");
    }

    public void mainmenu()
    {
        SceneManager.LoadScene("MainMenu");

    }

    

    public void quit()
    {
        Debug.Log("Quit!!!");
        Application.Quit();
    }

    public void mute()
    {
        PlayerPrefs.SetInt("Mute",1);
    }
    public void unmute()
    {
        PlayerPrefs.SetInt("Mute",0);
    }

    public void pause()
    {
     Time.timeScale = 0f;
     PlayerPrefs.SetInt("Mute",1);
    }

    public void resume()
    {
     Time.timeScale = 1f;
     PlayerPrefs.SetInt("Mute",0);
    }


    public void skin1()
    {
        PlayerPrefs.SetInt("Skin",0);
    }
    
    public void skin2()
    {
        PlayerPrefs.SetInt("Skin",1);
    }
    public void skin3()
    {
        PlayerPrefs.SetInt("Skin",2);
    }

    public void Level1()
    {
        SceneManager.LoadScene("Level1");

    }

    public void Level2()
    {
        SceneManager.LoadScene("Level2");

    }

    public void Level3()
    {
        SceneManager.LoadScene("Level3");

    }

    public void Level4()
    {
        SceneManager.LoadScene("Level4");

    }

    public void Level5()
    {
        SceneManager.LoadScene("Level5");

    }

    public void Level6()
    {
        SceneManager.LoadScene("Level6");

    }

    

}
