using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lose : MonoBehaviour {

    public bool lost;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionStay2D(Collision2D collision)
    {

        print("hit");

        if(collision.gameObject.tag == "body")
        {

            lost = true;

        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {

       

        if (collision.gameObject.tag == "body")
        {
            print("hit");
            lost = true;

        }


    }
}
