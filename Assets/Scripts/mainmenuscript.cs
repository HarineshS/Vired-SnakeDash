using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mainmenuscript : MonoBehaviour
{


    public Text ScoreText;
    public Text deathtext;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        ScoreText.text = PlayerPrefs.GetInt("Highscore").ToString();
        deathtext.text = PlayerPrefs.GetInt("Deathcount").ToString();

        
    }
}
