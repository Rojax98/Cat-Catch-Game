using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class joystickmoveRight : MonoBehaviour {

    public Transform centre;
    public GameObject loseLine;

    Vector3 lastPos;

    float distance;
    public float speed;

    // Use this for initialization
    void Start()   {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
            if (loseLine.GetComponent<lose>().lost == false)
            {

                distance = Vector3.Distance(centre.position, transform.position);


                if (RightStickPos().sqrMagnitude > 0.3f)
                {

                    transform.position += new Vector3(RightStickPos().x, RightStickPos().y, 0);

                }





                // if (Input.GetMouseButton(1))
                //  {

                //    transform.position = Vector2.Lerp(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), 0.1f);

                //}

                if (Input.GetKey(KeyCode.LeftArrow))
                {

                    transform.position += new Vector3(-speed, 0, 0);

                }

                if (Input.GetKey(KeyCode.RightArrow))
                {

                    transform.position += new Vector3(speed, 0, 0);

                }

                if (Input.GetKey(KeyCode.UpArrow))
                {

                    transform.position += new Vector3(0, speed, 0);

                }

                if (Input.GetKey(KeyCode.DownArrow))
                {

                    transform.position += new Vector3(0, -speed, 0);

                }

                if (Vector3.Distance(centre.position, transform.position) > 9f)
                {


                    transform.position = centre.position + (transform.position - centre.position).normalized * distance;


                }
            }



            // Debug.Log(centre.position + (transform.position - centre.position).normalized * distance);

        
    }



    Vector3 RightStickPos()
    {


        return new Vector3(Input.GetAxisRaw("RightStickH"), Input.GetAxisRaw("RightStickV"), 0);

    }


}