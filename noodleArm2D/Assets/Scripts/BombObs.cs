using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombObs : MonoBehaviour {
    Rigidbody2D otherbody;

    public bool hit;

    public GameObject arms;
    public GameObject cameraMain;

    float timer;

    float scale;
    // Use this for initialization
    void Start () {

        arms = GameObject.FindGameObjectWithTag("arms");
        cameraMain = GameObject.FindGameObjectWithTag("MainCamera");

    }
	
	// Update is called once per frame
	void Update () {

        scale = (cameraMain.GetComponent<zoom>().scale / 2f);

        transform.localScale = new Vector3(5.965938f, 5.965938f, 0) * scale;

        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);

        if (hit == true)
        {
            timer += 1;

            transform.localScale += new Vector3(1f * scale, 1f * scale,0);

            if(timer > 0.3f)
            {

                Destroy(gameObject);

            }
        }

        if (viewPos.y < -1)
        {

            Destroy(gameObject);

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        // print("hit");
        if (collision.gameObject.tag == "lArm" && hit == false)
        {
            Destroy(GetComponent<Rigidbody2D>());                      
            GetComponent<CircleCollider2D>().isTrigger = true;
            hit = true;

        }




        if (collision.gameObject.tag == "rArm" && hit == false)
        {
            Destroy(GetComponent<Rigidbody2D>());
            GetComponent<CircleCollider2D>().isTrigger = true;
            hit = true;

        }


    }
}
