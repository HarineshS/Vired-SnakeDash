using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fastchangingcolors : MonoBehaviour
{
    public GameObject playerObject;
    public GameObject CameraObject;
    public CameraScript cs;
    public SpriteRenderer SR;
    public PlayerMovement pm;





    // Start is called before the first frame update
    void Start()
    {
        setrandomcolor();
    }



    void  Awake() 
    {
        pm = playerObject.GetComponent<PlayerMovement>();
        cs= CameraObject.GetComponent<CameraScript>();
        
    }

    // Update is called once per frame
    void Update()
    {

        StartCoroutine(ColChange());
        
    }

    public IEnumerator ColChange()
    {
        
        setrandomcolor();
        yield return new  WaitForSeconds(4f);

    }

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
