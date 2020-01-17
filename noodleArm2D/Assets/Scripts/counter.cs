using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class counter : MonoBehaviour {

    public TextMesh text;

    public float timer;

    bool collide = false;

    float collisions;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        text.text = ((Mathf.Round(timer))*100/100).ToString();


        if(collisions > 0)
        {

            timer += 1 * Time.deltaTime;

        }

        if(collisions == 0)
        {

            timer = 0;

        }
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
      
        if(col.gameObject.tag == "Obstacle")
        {

            collisions++;

        }
        


    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Obstacle")
        {

            collisions--;

        }
    }

}
