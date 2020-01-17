using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ignoreCol : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
	}

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "rArm" || collision.gameObject.tag == "lArm") 
        {

            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }

    }

}
