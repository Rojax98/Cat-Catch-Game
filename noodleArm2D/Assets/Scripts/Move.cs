using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Rigidbody2D rb;

    public GameObject mousePos;
    public Transform body;
    public GameObject coliding;


    public Transform centre;

    public Transform currentPos;

    bool right;
    bool setPos;

    Vector3 lastPos;

    // Use this for initialization
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        lastPos = joyPos();
    }

    // Update is called once per frame
    void FixedUpdate()
    {



        Vector2 mousePos = Input.mousePosition;

        Vector2 mPos = Camera.main.ScreenToWorldPoint(mousePos);


        if (Input.GetMouseButtonDown(1))
        {
            if (right == false)
            {
                right = true;

            }

            else if (right == true)
            {
                right = false;

            }

        }



            setPos = false;
          
            transform.position = joyPos();

            lastPos = joyPos();
                
            
 

        if (RightStickPos().sqrMagnitude < 0.3f)
        {

            transform.position = lastPos ;

        }


       

    }


    Vector3 RightStickPos()
    {

        return new Vector3(Input.GetAxisRaw("RightStickH"), Input.GetAxisRaw("RightStickV"), 0);

    }

    Vector3 joyPos()
    {

        return new Vector3(mousePos.transform.position.x, mousePos.transform.position.y, 0);


    }
    //use Vector3.Dot for grabbing items

}
