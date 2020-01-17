using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreLoad : MonoBehaviour
{

    public GameObject currentScore;
    public GameObject highScore;

    float score;
    float HiScore;

    // Start is called before the first frame update
    void Start()
    {

        score = PlayerPrefs.GetFloat("gameScore",0);
        HiScore = PlayerPrefs.GetFloat("highscore", 0); 

    }

    // Update is called once per frame
    void Update()
    {
        if (currentScore)
        {
            currentScore.GetComponent<Text>().text = "Your Score: " + score.ToString();

        }


        highScore.GetComponent<Text>().text = "Highscore: " + HiScore.ToString();

    }
}
