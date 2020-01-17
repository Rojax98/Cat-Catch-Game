using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followMouse : MonoBehaviour
{

    bool follow = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {



        Vector2 mousePos = Input.mousePosition;

        Vector2 mPos = Camera.main.ScreenToWorldPoint(mousePos);


        transform.position = mPos;




    }
}
