using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class regularobstacle : MonoBehaviour
{
    public GameObject playerObject;
    public GameObject CameraObject;
    public CameraScript cs;
    public SpriteRenderer SR;
    public PlayerMovement pm;
    // Start is called before the first frame update
    void Start()
    {
        // 
        setrandomcolor();
        //checkbgcolor();
        
    }
    void  Awake() 
    {
        pm = playerObject.GetComponent<PlayerMovement>();
        cs= CameraObject.GetComponent<CameraScript>();
        
    }

    // Update is called once per frame
    void Update()
    {
        checkbgcolor();

    }


    //---------------------------Check if the bgcolor is same as the obstacle color---------------------------
    void checkbgcolor()
    {
        Color myColor = SR.color;
        if(myColor==cs.BGColor)
        {
            Destroy(this.gameObject);
            print("object destroyed");
        }

    }
    

    //----------------------------Set a random color to the obstacle on start----------------------------------
     void setrandomcolor()
    {
        int number = Random.Range(0, 4);

        switch (number)
        {
            case 0:
                SR.color = pm.colBlue;
               
                
               
                break;
            case 1:
                SR.color = pm.colPink;
               
               
                break;
            case 2:
                SR.color = pm.colPurple;
               
               
                break;
            case 3:
                SR.color = pm.colYellow;
                
                
                break;

        }
    }
    
}
