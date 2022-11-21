using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class narrower : MonoBehaviour
{

    public GameObject go;
    public GameObject Player;
    //public GameObject rightobs;
    public float speed;
    public Vector3 newpos;
    public float dist;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkdistance();

        
    }

    // void OnCollisionEnter2D(Collision2D col)
    // {

        
    //     gameObject.GetComponent<Collider2D>().enabled=false;
    // }

    public void checkdistance()
    {
        if(this.transform.position.y-dist < Player.transform.position.y)
        {
            movetocenter();
        }
    }
    public void movetocenter()
    {
        Vector3 stratpos = this.transform.position;
        if(transform.position.x>0)
        {
            newpos = new Vector3(4, this.transform.position.y, this.transform.position.z);
            transform.position= Vector3.Lerp(stratpos,newpos,Time.deltaTime);

        }
        else
        {
            newpos = new Vector3(-4, this.transform.position.y, this.transform.position.z);
            transform.position= Vector3.Lerp(stratpos,newpos,speed*Time.deltaTime);

        }
        
        
    }
}
