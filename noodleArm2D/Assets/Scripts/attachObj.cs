using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attachObj : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            Destroy(collision.gameObject.GetComponent<Rigidbody2D>());
            Destroy(collision.gameObject.GetComponent<Collider2D>());
            collision.gameObject.transform.parent = gameObject.transform.parent;
        }
    }
}
