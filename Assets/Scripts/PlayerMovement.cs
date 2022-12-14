using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    
    public float vertical;
    public float horizontal;

    public float xpos;  
    public float Speed =.3f;

    public float movespeed = 5f;

    public Rigidbody2D body;
    
    public SpriteRenderer sr;
    public TrailRenderer trr;

    public string CurColor;

    public Color colBlue;
    public Color colYellow;
    public Color colPurple;
    public Color colPink;


    public ParticleSystem Particles;

    public CameraScript cs;
    public GameObject CameraObject;

    public Text scoretext;
    public Text Highscoretext;

    public Canvas canvas;
    public Canvas FinishCanvas;



    public int score;




    public GameView gv;
    public GameObject gvObject;


    public AudioSource as1;
    public AudioSource as2;


    

    
    


    void Awake()
    {
        cs= CameraObject.GetComponent<CameraScript>();
        Particles=GetComponentInChildren<ParticleSystem>();
        score = 0;
    }



    void Start()
    {
        gameObject.SetActive(true);
        StartCoroutine(ColChange());
        scoretext.GetComponent<Text>().text = "0";
        Highscoretext.GetComponent<Text>().text = PlayerPrefs.GetInt("Highscore").ToString();



        gv = gvObject.GetComponent<GameView>();

        
    }

    // Update is called once per frame
    void Update()
    {

            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
         
         
            vertical = Input.GetAxis("Vertical");
            horizontal = Input.GetAxis("Mouse X");

            if(Input.GetMouseButtonDown(0))
            {
                StartCoroutine(ColChange());

            }

            if(cs.BGColor == sr.color)
            {
                StartCoroutine(ColChange());
            }

            xpos = transform.position.x;
            move();
            
            mousechange();
            bound();


            if(PlayerPrefs.GetInt("Highscore") < score)
            {
                PlayerPrefs.SetInt("Highscore",score);
                Highscoretext.GetComponent<Text>().text = PlayerPrefs.GetInt("Highscore").ToString();
            }

           
    }

//------------------Clamp movement in x axis ------------------------
    public void bound()
    {
        xpos = Mathf.Clamp(transform.position.x,-2.5f,2.5f);

        transform.position = new Vector3(xpos,transform.position.y,transform.position.z);
        
    }

//------------------movement ------------------------
    public void move()
    {
        
        transform.position = transform.position + new Vector3(0, 0.3f * Speed * Time.deltaTime, 0);
        
            
        
    }
    public void wiggle()
    {
        body.velocity = new Vector2(horizontal * movespeed, 0);
    }

//------------------mouse Input ------------------------
    public void mousechange()
    {
        if (Input.GetMouseButton(0))
        {
            
            wiggle();
        }
        if (Input.GetMouseButtonUp(0))
        {
            // CurColor = "Pink";
            // sr.color = colPink;
            // trr.startColor = colPink;
            // trr.endColor = colPink;


        }
    }






//------------------color change ------------------------
    public IEnumerator ColChange()
    {
        
        SetColor();
        yield return new  WaitForSeconds(1f);

    }

    void SetColor()
    {
        int number = Random.Range(0, 4);

        switch (number)
        {
            case 0:
                CurColor = "Blue";
                sr.color = colBlue;
                trr.startColor = colBlue;
                trr.endColor = colBlue;
                break;
            case 1:
                CurColor = "Yellow";
                sr.color = colYellow;
                trr.startColor = colYellow;
                trr.endColor = colYellow;
                break;
            case 2:
                CurColor = "Purple";
                sr.color = colPurple;
                trr.startColor = colPurple;
                trr.endColor = colPurple;
                break;
            case 3:
                CurColor = "Pink";
                sr.color = colPink;
                trr.startColor = colPink;
                trr.endColor = colPink;
                break;

        }
    }

//------------------Collision Interaction --------------------------------

void OnCollisionEnter2D(Collision2D col)
{
    as1.Play();
    print("score :");
    print(score);
    
    Color myColor = sr.color;
    Color otherColor = col.gameObject.GetComponent<SpriteRenderer>().color;
    if(myColor==(otherColor) )
    {
        // Disable the collider
        // print("collision is occuring");
        col.gameObject.GetComponent<Collider2D>().enabled=false;
        score+=10;
        scoretext.text = score.ToString();
        
    }
    else
    
    {
        if(col.gameObject.tag=="Finish")
        {
            StartCoroutine(LevelComplete());  
            print("Level Complete");
            //Destroy(col.gameObject);
            gv.levelCompleted();
            return;
        }
        if(col.gameObject.tag=="colchanger")
        {
            as2.Play();
            sr.color = otherColor;
            trr.startColor = otherColor;
            trr.endColor = otherColor;
            col.gameObject.GetComponent<Collider2D>().enabled=false;
            score+=10;
            scoretext.text = score.ToString();
            return;
        }
        else
        {
            StartCoroutine(Destroy());  
            print("Different colors");
            gv.gameOver();
        }
    } 

    
}


//------------------Destroy player ------------------------

private IEnumerator Destroy()
{
    Particles.Play();
    Handheld.Vibrate();
    //canvas.GetComponent<Canvas> ().enabled = true;
    sr.enabled=false;
    this.GetComponent<Collider2D>().enabled=false;
    trr.enabled=false;

    yield return new WaitForSeconds(1f);
    Destroy(this.gameObject);

    
    
    
}

private IEnumerator LevelComplete()
{
    Particles.Play();
    Handheld.Vibrate();
    // canvas.GetComponent<Canvas> ().enabled = false;
    // FinishCanvas.GetComponent<Canvas> ().enabled = true;
    sr.enabled=false;
    this.GetComponent<Collider2D>().enabled=false;
    trr.enabled=false;

    yield return new WaitForSeconds(2f);
    Destroy(this.gameObject);

    
    
    
    
}




}
