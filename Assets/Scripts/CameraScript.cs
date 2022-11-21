using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public PlayerMovement playermovement;
    public GameObject playerObject;
    //public Camera camera;
    public Transform player;
    public Color BGColor;
    // Start is called before the first frame update
    void Awake()
    {

        playermovement = playerObject.GetComponent<PlayerMovement>();
        setrandomcolor();
    }
    
    
    void Start()
    {

    
        
    }

    // Update is called once per frame
    void Update()
    {
        //-----------------Follow player--------------
        transform.position = new Vector3(transform.position.x,player.position.y+3,player.position.z);
        BGColor= Camera.main.GetComponent<Camera>().backgroundColor;
        
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
}
