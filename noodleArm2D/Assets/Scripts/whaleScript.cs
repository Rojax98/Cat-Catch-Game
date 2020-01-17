using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whaleScript : MonoBehaviour
{


    Rigidbody2D otherbody;

    bool hit;

    public GameObject arms;
    public GameObject cameraMain;
    public GameObject scoreAdd;
    public GameObject scoreMinus;

    // Use this for initialization
    void Start()
    {

        transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));

        arms = GameObject.FindGameObjectWithTag("arms");
        cameraMain = GameObject.FindGameObjectWithTag("MainCamera");

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);

        if (hit == true)
        {



            if (viewPos.x < 0.2 || viewPos.x > 0.8)
            {

                cameraMain.GetComponent<zoom>().zoomOut = true;
            }

            if (viewPos.y < 0.2 || viewPos.y > 0.8)
            {

                cameraMain.GetComponent<zoom>().zoomOut = true;
            }



        }

        if (viewPos.y < -1)
        {

            Destroy(gameObject);

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (hit == false)
        {
            // print("hit");
            if (collision.gameObject.tag == "lArm")
            {
                Instantiate(scoreAdd, transform.position, Quaternion.identity);
                Destroy(GetComponent<Rigidbody2D>());
                transform.SetParent(collision.transform);
                tag = "lArm";
                gameObject.layer = 12;
                arms.GetComponent<Balance>().leftObs.Add(gameObject);
                arms.GetComponent<Balance>().whales.Add(gameObject);
                GetComponent<BoxCollider2D>().isTrigger = true;
                hit = true;

            }




            if (collision.gameObject.tag == "rArm")
            {
                Instantiate(scoreAdd, transform.position, Quaternion.identity);
                Destroy(GetComponent<Rigidbody2D>());
                transform.SetParent(collision.transform);
                tag = "rArm";
                gameObject.layer = 12;
                arms.GetComponent<Balance>().rightObs.Add(gameObject);
                arms.GetComponent<Balance>().whales.Add(gameObject);
                GetComponent<BoxCollider2D>().isTrigger = true;
                hit = true;

            }

        }

        if (collision.gameObject.tag == "bomb")
        {
            
            print("bomb");

            if (collision.gameObject.GetComponent<BombObs>().hit == true)
            {
                Instantiate(scoreMinus, transform.position, Quaternion.identity);

                if (tag == "rArm")
                {
                    
                    arms.GetComponent<Balance>().rightObs.Remove(gameObject);
                    arms.GetComponent<Balance>().whales.Remove(gameObject);
                    Destroy(gameObject);
                }

                if (tag == "lArm")
                {
                    arms.GetComponent<Balance>().leftObs.Remove(gameObject);
                    arms.GetComponent<Balance>().whales.Remove(gameObject);
                    Destroy(gameObject);

                }


            }

        }


    }





}
