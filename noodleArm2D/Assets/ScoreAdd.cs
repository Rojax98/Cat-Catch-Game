using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreAdd : MonoBehaviour
{

    public TextMesh scoreAmount;
    public GameObject scorePos;
    public GameObject canvas;
    public GameObject cameraMain;
    public GameObject loseLine;

    bool fade;

    // Start is called before the first frame update
    void Start()
    {
        scoreAmount = GetComponent<TextMesh>();
        scorePos = GameObject.FindGameObjectWithTag("Score");
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        cameraMain = GameObject.FindGameObjectWithTag("MainCamera");
        loseLine = GameObject.FindGameObjectWithTag("Lose");
        //transform.parent = canvas.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (loseLine.GetComponent<lose>().lost == false)
        {

            transform.localScale = new Vector3(0.11893f, 0.11893f, 0) * cameraMain.GetComponent<zoom>().scale;

            transform.position = Vector3.Lerp(transform.position, scorePos.transform.position, 0.05f);

            if (fade == true)
            {
                var col = scoreAmount.color;
                col.a -= 0.01f;

                scoreAmount.color = col;

                if (col.a <= 0)
                {

                    Destroy(gameObject);

                }
            }

        }

        if (loseLine.GetComponent<lose>().lost == true)
        {
            var col = scoreAmount.color;
            col.a = 0;

            scoreAmount.color = col;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.tag == "Score")
        {
            print("Hit");
            fade = true;

        }


    }
}
