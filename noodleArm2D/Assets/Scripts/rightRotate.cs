using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rightRotate : MonoBehaviour {

    Rigidbody2D rb;

    public Transform centre;

    public Transform pos;

    // Use this for initialization
    void Start () {

        rb = GetComponent<Rigidbody2D>();
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        float angle = Mathf.Atan2(centre.position.y - transform.position.y, centre.position.x - transform.position.x) * 180 / Mathf.PI;

        transform.rotation = Quaternion.Euler(0, 0, angle + 180);



        //transform.position = pos.position;

       


    }

  
}


