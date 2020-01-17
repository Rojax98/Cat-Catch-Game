using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class moveBod : MonoBehaviour {

    public bool move;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetAxis("LeftTrigger") > 0.1f)
        {

            move = false;

        }
        //else
        //{
        
        //    move = true;

        //}



    }

}
