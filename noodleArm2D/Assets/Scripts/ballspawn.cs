using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballspawn : MonoBehaviour {


    public GameObject Obstacle;
    public GameObject Shark;
    public GameObject Player;
    public GameObject camera;
    public GameObject bombObs;
    public GameObject loseLine;
    public GameObject Whale;

    float timer;

    float scale;

    float bombTimer;

    public float bombChance;

	// Use this for initialization
	void Start () {

        bombChance = 1f;
        scale = 1;
	}
	
	// Update is called once per frame
	void Update () {

        if (loseLine.GetComponent<lose>().lost == false)
        {
            if (scale <= 5)
            {
                scale = camera.GetComponent<zoom>().scale;
            }

            timer += 1 * Time.deltaTime;

            if (bombTimer < 15)
            {
                bombTimer += 1 * Time.deltaTime;
            }

            if(scale > 5)
            {
                scale = 5;

            }

            if (timer > 2 / scale)
            {
                if (bombTimer > 10)
                {
                    bombChance = Random.Range(0, 1f);
                    
                }

                //print(bombChance);

                if(Player.GetComponent<Balance>().score > 20 && Player.GetComponent<Balance>().score < 100)
                {

                    
                   
                        
                        Instantiate(Shark, new Vector3(Random.Range(-20 * scale, 20 * scale), transform.position.y, 0), Quaternion.identity);
                    

                }

                if (Player.GetComponent<Balance>().score > 100)
                {                 

                        Instantiate(Whale, new Vector3(Random.Range(-50 * scale, 50 * scale), transform.position.y, 0), Quaternion.identity);
                    

                }

                if (bombChance > 0.1f && Player.GetComponent<Balance>().score < 20)
                {

                    Instantiate(Obstacle, new Vector3(Random.Range(-10 * scale, 10 * scale), transform.position.y, 0), Quaternion.identity);
                }

                if (bombChance < 0.1f)
                {
                    var xSpawn = Random.Range(-23 * scale, 23 * scale);

                    if (xSpawn < 15 * scale || xSpawn > 15 * scale)
                    {

                        Instantiate(bombObs, new Vector3(xSpawn, transform.position.y, 0), Quaternion.identity);
                    }
                }

                timer = 0;
            }

            Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);

            //print(viewPos.y);

            if (viewPos.y < 2.6)
            {
                transform.position += new Vector3(0, 1, 0);

            }
        }

        

    }

    

  
}
