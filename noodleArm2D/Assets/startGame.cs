using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startGame : MonoBehaviour
{

    public GameObject left;
    public GameObject right;
    public GameObject fade;
    public TextMesh startT;
    float timer;
    bool start;

    // Start is called before the first frame update
    void Start()
    {
        timer = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {

            Application.Quit();
            
        }

        if (start == false)
        {
            if (left.GetComponent<startZone>().inZone == true && right.GetComponent<startZone>().inZone == true)
            {
                var timerR = Mathf.Round(timer);
                timer -= 1 * Time.deltaTime;
                startT.text = timerR.ToString();
                if (timer <= 0)
                {
                    timer = 0;
                    print("startGame");
                    start = true;



                }

            }
            else
            {

                timer = 3;
                startT.text = "Raise Both Arms to Start";
            }

        }

        if(start == true)
        {
            var tempCol = fade.GetComponent<SpriteRenderer>().color;
            tempCol.a += 0.01f;
            fade.GetComponent<SpriteRenderer>().color = tempCol;

            if(tempCol.a >= 1)
            {

                SceneManager.LoadScene(1);

            }
        }


    }
}
