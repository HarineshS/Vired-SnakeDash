using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clusterscript : MonoBehaviour
{

    
    public GameObject playerObject;

    public Color newcolor;
    public PlayerMovement pm;
    
    // Start is called before the first frame update
    void Start()
    {
        pm = playerObject.GetComponent<PlayerMovement>();
        
        assignrandomcolor();
        ChangeChildColor();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeChildColor()
    {
       
    foreach (SpriteRenderer SR in this.GetComponentsInChildren<SpriteRenderer>())
    {
        SR.color = newcolor;

        
    }
    }

    public void assignrandomcolor()
    {
        int number = Random.Range(0, 4);

        switch (number)
        {
            case 0:
                newcolor = pm.colBlue;
               
                
               
                break;
            case 1:
                newcolor = pm.colPink;
               
               
                break;
            case 2:
                newcolor = pm.colPurple;
               
               
                break;
            case 3:
                newcolor = pm.colYellow;
                
                
                break;

        }
    }
   
}
