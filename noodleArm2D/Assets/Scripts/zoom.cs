using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class zoom : MonoBehaviour {

    public bool zoomOut;
    public GameObject loseLine;
    public GameObject Player;

    public GameObject leftWarn;
    public GameObject rightWarn;

    public Transform line;
    public Transform cat;
    public Transform playerPos;

    float timer;

    public float scale;

    Color left;
    Color right;

    float flashtimer;
	// Use this for initialization
	void Start () {

        left = leftWarn.GetComponent<SpriteRenderer>().color;
        right = rightWarn.GetComponent<SpriteRenderer>().color;

        left.a = 0;
        right.a = 0;

        leftWarn.GetComponent<SpriteRenderer>().color = left;
        rightWarn.GetComponent<SpriteRenderer>().color = right;

    }
	
	// Update is called once per frame
	void Update () {

        // print(cat.position.y - line.position.y);

        if (cat.position.y - line.position.y > 13 || loseLine.GetComponent<lose>().lost == true)
        {
            left.a = 0;
            right.a = 0;

            leftWarn.GetComponent<SpriteRenderer>().color = left;
            rightWarn.GetComponent<SpriteRenderer>().color = right;
        }

            float size = Camera.main.orthographicSize;

        if (loseLine.GetComponent<lose>().lost == false)
        {
            if (cat.position.y - line.position.y < 13)
            {
                float intensity = (cat.position.x - line.position.x);

                //transform.position += new Vector3(Random.Range(0, 0.01f * (intensity + scale)), Random.Range(0, 0.01f * (intensity + scale)), 0);
                //transform.position -= new Vector3(Random.Range(0, 0.01f * (intensity + scale)), Random.Range(0, 0.01f * (intensity + scale)), 0);

                if(playerPos.rotation.z > 0)
                {
                    print("flashLeft");

                    leftWarn.GetComponent<SpriteRenderer>().color = left;

                    flashtimer += 1 * Time.deltaTime;

                    if(flashtimer < 0.2f)
                    {

                        left.a = 0.4f;

                    }

                    if (flashtimer < 0.4f && flashtimer > 0.2f)
                    {

                        left.a = 0;

                    }

                    if(flashtimer > 0.4f)
                    {

                        flashtimer = 0;

                    }



                }

                if (playerPos.rotation.z < 0)
                {
                    print("flashLeft");

                    rightWarn.GetComponent<SpriteRenderer>().color = right;

                    flashtimer += 1 * Time.deltaTime;

                    if (flashtimer < 0.2f)
                    {

                        right.a = 0.4f;

                    }

                    if (flashtimer < 0.4f && flashtimer > 0.2f)
                    {

                        right.a = 0;

                    }

                    if (flashtimer > 0.4f)
                    {

                        flashtimer = 0;

                    }



                }

            }

            if (zoomOut == true)
            {
                if (Player.GetComponent<Balance>().score < 20)
                {


                    size += 0.05f;

                }

                if (Player.GetComponent<Balance>().score > 20)
                {


                    size += 1f;

                }

                timer += 1 * Time.deltaTime;

                if (timer > 0.5f)
                {
                    zoomOut = false;
                    timer = 0;
                }
                    
            }
        }

        if (loseLine.GetComponent<lose>().lost == true)
        {


            if (scale >= 1)
            {
                timer = 0;
                size -= 1f * scale;

              
            }

            if(scale <= 1)
            {

                timer += 1 * Time.deltaTime;


                if (timer > 3)
                {
                    SceneManager.LoadScene(2);
                }

            }

        }

        Camera.main.orthographicSize = size;

        scale = (size / 0.14f)/ 100;

        //Debug.Log(Camera.main.fieldOfView = fov);



    }
}
