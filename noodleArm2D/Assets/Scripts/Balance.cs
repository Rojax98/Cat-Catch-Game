using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Balance : MonoBehaviour {

    public GameObject centre;

    public GameObject WeightAv;
    public GameObject loseLine;
    public GameObject camera;
    public GameObject hiScoreText;


    public Text scoreT;
    public Text highScore;
    

    public List<GameObject> leftObs = new List<GameObject>();
    public List<GameObject> rightObs = new List<GameObject>();
    public List<GameObject> smallFish = new List<GameObject>();
    public List<GameObject> sharks = new List<GameObject>();
    public List<GameObject> whales = new List<GameObject>();

    public float balance;

    public float score;
    public float hiScore;

    public float Weight;
    float scale;

    public Vector3 balancePoint;

    float offset;
    float hiScoreCounter;

    bool hiScoreCel;
    bool scaleOut;
    bool scaleIn;


    Vector3 sumLeft;
    Vector3 sumRight;

	// Use this for initialization
	void Start () {
        LoadHighScore();

        leftObs.Add(centre);
        rightObs.Add(centre);
        if (hiScoreText)
        {
            var col = hiScoreText.GetComponent<Text>().color;
            col.a = 0.00f;
            hiScoreText.GetComponent<Text>().color = col;
        }

        Application.targetFrameRate = 60;

    }

    // Update is called once per frame
    void Update()
    {
        print(hiScore);
        if (Input.GetKey(KeyCode.P))
        {

            //PlayerPrefs.DeleteAll();

        }

        sharkCount();
        whaleCount();
        smallFishCount();


        if (camera)
        {
            scale = camera.GetComponent<zoom>().scale;
        }

        if (hiScoreCel == true)
        {

            hiScoreCounter += 1 * Time.deltaTime;

            if (hiScoreText.transform.localScale.x <= 0.3831557f)
            {
                scaleOut = true;
                scaleIn = false;
            }


            if (hiScoreText.transform.localScale.x >= 0.6f)
            {
                scaleOut = false;
                scaleIn = true;
            }

            if (scaleOut == true)
            {
                hiScoreText.transform.localScale += new Vector3(0.01f, 0.01f, 0);
            }

            if (scaleIn == true)
            {
                hiScoreText.transform.localScale -= new Vector3(0.01f, 0.01f, 0);
            }

            if (hiScoreCounter > 2)
            {

                var col = hiScoreText.GetComponent<Text>().color;
                col.a -= 0.01f;
                hiScoreText.GetComponent<Text>().color = col;

            }
            if (hiScoreCounter < 2)
            {

                var col = hiScoreText.GetComponent<Text>().color;
                col.a = 1f;
                hiScoreText.GetComponent<Text>().color = col;

            }

        }

        if (Input.GetButtonUp("X") || Input.GetKeyUp(KeyCode.R))
        {


            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
       
            if (loseLine.GetComponent<lose>().lost == false)
            {

                score = ((whales.Count) * 10) + ((sharks.Count) * 5) + (smallFish.Count);

            if (scoreT)
            {
                scoreT.text = "Score: " + score.ToString();
                highScore.text = "Highscore!!";
            }

                AveragePos();


                if (Weight > 6f)
                {

                    Weight = 6f;

                }
                Weight = (rightObs.Count + leftObs.Count) * 0.25f;

                if (score >= 2 && score < 40)
                {

                    balance = -WeightAv.transform.localPosition.x * (10f + Weight) / 2f;

                    transform.Rotate(0, 0, balance / 10);
                }

                if (score > 40 && score < 100)
                {

                    balance = -WeightAv.transform.localPosition.x * (10f + Weight) / 3f;

                    transform.Rotate(0, 0, balance / 10);
                }

                if (score > 100 && score < 200)
                {

                    balance = -WeightAv.transform.localPosition.x * (10f + Weight) / 4f;

                    transform.Rotate(0, 0, balance / 10);

                }

                if (score > 200 && score < 500)
                {

                    balance = -WeightAv.transform.localPosition.x * (10f + Weight) / 7f;

                    transform.Rotate(0, 0, balance / 10);


                }

                if (score > 500)
                {

                    balance = -WeightAv.transform.localPosition.x * (10f + Weight) / 10f;

                    transform.Rotate(0, 0, balance / 10);
                }

                balancePoint = (sumLeft + sumRight) / 2f;

                WeightAv.transform.position = balancePoint;

            }

            if (score > hiScore)
            {
                hiScoreCel = true;
                hiScore = score;

            }

            if (loseLine.GetComponent<lose>().lost == true)
            {
                PlayerPrefs.SetFloat("gameScore", score);
                StoreHighscore(hiScore);

            }

        

    }

    void LoadHighScore()
    {
       
        hiScore = PlayerPrefs.GetFloat("highscore", 0);
       // print(hiScore);
    }

    void StoreHighscore(float newHighscore)
    {   
        
        float oldHighscore = PlayerPrefs.GetFloat("highscore", 0);
        if (newHighscore > oldHighscore)
            PlayerPrefs.SetFloat("highscore", newHighscore);
        
    }

    void smallFishCount()
    {


        for (int i = 0; i < smallFish.Count; i++)
        {
            if (smallFish[i] == null)
            {
                smallFish.Remove(smallFish[i]);
            }
        }

    }


    void sharkCount()
    {


        for (int i = 0; i < sharks.Count; i++)
        {
            if (sharks[i] == null)
            {
                sharks.Remove(sharks[i]);
            }
        }

    }

    void whaleCount()
    {


        for (int i = 0; i < whales.Count; i++)
        {
            if (whales[i] == null)
            {
                whales.Remove(whales[i]);
            }
        }

    }

    void AveragePos()
    {

        sumLeft = new Vector3(0,0,0);

        if (leftObs.Count > 0)
        {

            for (int i = 0; i < leftObs.Count; i++)
            {
                if (leftObs[i] == null)
                {
                    leftObs.Remove(leftObs[i]);
                }
                if (leftObs[i] != null)
                {
                    sumLeft += leftObs[i].transform.position;
                }

            }

        }

        sumLeft = sumLeft / leftObs.Count;       

        sumRight = new Vector3(0, 0, 0);

        if (rightObs.Count > 0)
        {

            for (int i = 0; i < rightObs.Count; i++)
            {
                if (rightObs[i] == null)
                {
                    rightObs.Remove(rightObs[i]);
                }

                if (rightObs[i] != null)
                {
                    sumRight += rightObs[i].transform.position;
                }


            }
        }

        sumRight = sumRight / rightObs.Count;

        
    }
}
