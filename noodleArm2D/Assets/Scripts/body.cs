using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class body : MonoBehaviour {

    Rigidbody2D rb;

    public GameObject lArm;
    public GameObject rArm;

	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody2D>();
		
	}
	
	// Update is called once per frame
	void Update () {

        if(GetComponent<moveBod>().move == true)
        {
            //   print("body move");
            //transform.position = Vector2.Lerp(transform.position, rArm.transform.position, 0.01f);

           // rb.velocity = LeftStickPos() * 15f;

        }

        if (GetComponent<moveBod>().move == false)
        {
            // print("body move");
           // rb.velocity = Vector3.zero;
        }

    }

    Vector3 LeftStickPos()
    {


        return new Vector3(Input.GetAxisRaw("LeftStickH"), Input.GetAxisRaw("LeftStickV"), 0);

    }
}
