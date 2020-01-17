using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTime : MonoBehaviour {

    int counter;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        counter += 1;


        if(counter > 10)
        {

            //Destroy(gameObject);
        }
		
	}
}
