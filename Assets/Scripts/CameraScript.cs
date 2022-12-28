using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public PlayerMovement playermovement;
    public GameObject playerObject;
    //public Camera camera;
    public Transform player;

    public SpriteRenderer sr;
    public Color BGColor;

    private Vector3 defaultpos;


    
    void Awake()
    {

        playermovement = playerObject.GetComponent<PlayerMovement>();
        setrandomcolor();
        sr = playerObject.GetComponent<SpriteRenderer>();
    }
    
    
    void Start()
    {
        

    
        
    }

    // Update is called once per frame
    void Update()
    {
        //-----------------Follow player--------------
        if(sr.enabled == false)
        {
            defaultpos = new Vector3(0,transform.position.y,transform.position.z);
            StartCoroutine(camerashake());
            transform.position = defaultpos;
            StopCoroutine(camerashake());
            

        }
        else
        {
            transform.position = new Vector3(transform.position.x,player.position.y+2,player.position.z);
            BGColor= Camera.main.GetComponent<Camera>().backgroundColor;

        }
        // transform.position = new Vector3(transform.position.x,player.position.y+3,player.position.z);
        // BGColor= Camera.main.GetComponent<Camera>().backgroundColor;
        
    }

    //----------------------------Set a random color to the obstacle on start----------------------------------
    void setrandomcolor()
    {
        int number = Random.Range(0, 4);

        switch (number)
        {
            case 0:
                Camera.main.GetComponent<Camera>().backgroundColor = playermovement.colBlue;
               
                
               
                break;
            case 1:
                Camera.main.GetComponent<Camera>().backgroundColor = playermovement.colPink;
               
               
                break;
            case 2:
                Camera.main.GetComponent<Camera>().backgroundColor = playermovement.colPurple;
               
               
                break;
            case 3:
                Camera.main.GetComponent<Camera>().backgroundColor = playermovement.colYellow;
                
                
                break;

        }
    }

    //----------------------------Camera shake coroutine--------------------------------

    public IEnumerator camerashake()
    {
        
        transform.position = new Vector3(defaultpos.x-0.5f, defaultpos.y,defaultpos.z);
        yield return new WaitForSeconds(.1f);
        
        transform.position = new Vector3(defaultpos.x+0.5f, defaultpos.y,defaultpos.z);
        yield return new WaitForSeconds(.1f);

        transform.position = new Vector3(defaultpos.x-0.3f, defaultpos.y,defaultpos.z);
        yield return new WaitForSeconds(.1f);

        transform.position = new Vector3(defaultpos.x+0.3f, defaultpos.y,defaultpos.z);
        yield return new WaitForSeconds(.1f);
        
        transform.position = new Vector3(defaultpos.x, defaultpos.y, defaultpos.z);
        yield break;
    }
}
