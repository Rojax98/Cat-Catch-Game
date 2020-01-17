using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveLeft : MonoBehaviour {

    public GameObject mousePos;

    public GameObject coliding;

    public Transform body;

    Rigidbody2D rb;

    public Transform centre;

    public Transform currentPos;

    bool left;

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

        

        //print(mPos);

        if (Input.GetMouseButtonDown(0))
        {
            if (left == false)
            {
                left = true;

            }

            else if (left == true)
            {
                left = false;

            }

        }




        transform.position = joyPos();
        lastPos = joyPos();

        
           



        if (LeftStickPos().sqrMagnitude < 0.3f && coliding.GetComponent<moveBod>().move == false)
        {

            transform.position = lastPos ;

        }


    }

    Vector3 LeftStickPos()
    {


        return new Vector3(Input.GetAxisRaw("LeftStickH"), Input.GetAxisRaw("LeftStickV"), 0);

    }

    Vector3 joyPos()
    {

        return new Vector3(mousePos.transform.position.x, mousePos.transform.position.y, 0);


    }
}
