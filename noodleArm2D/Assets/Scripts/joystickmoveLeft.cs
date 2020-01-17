using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class joystickmoveLeft : MonoBehaviour {

    public Transform centre;
    public GameObject loseLine;

    bool resetPos;

    Vector3 lastPos;

    public float speed;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        
            if (loseLine.GetComponent<lose>().lost == false)
            {

                var distance = Vector3.Distance(centre.position, transform.position);


                if (LeftStickPos().sqrMagnitude > 0.3f)
                {

                    transform.position += new Vector3(LeftStickPos().x, LeftStickPos().y, 0);

                }


                //if (Input.GetMouseButton(0))
                //{

                //transform.position = Vector2.Lerp(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), 0.1f);

                if (Input.GetKey(KeyCode.A))
                {

                    transform.position += new Vector3(-speed, 0, 0);

                }

                if (Input.GetKey(KeyCode.D))
                {

                    transform.position += new Vector3(speed, 0, 0);

                }

                if (Input.GetKey(KeyCode.W))
                {

                    transform.position += new Vector3(0, speed, 0);

                }

                if (Input.GetKey(KeyCode.S))
                {

                    transform.position += new Vector3(0, -speed, 0);

                }

                // }

                if (Vector3.Distance(centre.position, transform.position) > 9f)
                {

                    transform.position = centre.position + (transform.position - centre.position).normalized * distance;
                }

            }
        
    }



    Vector3 LeftStickPos()
    {


        return new Vector3(Input.GetAxisRaw("LeftStickH"), Input.GetAxisRaw("LeftStickV"), 0);

    }
}
