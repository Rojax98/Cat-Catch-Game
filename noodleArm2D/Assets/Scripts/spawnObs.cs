using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnObs : MonoBehaviour {

    public GameObject Obstacle;
    public GameObject SpawnOne;
    public GameObject SpawnTwo;
    public GameObject SpawnThree;
    public GameObject SpawnFour;
    float Timer = 0;

    Vector2 Spawn;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        Timer += 1 * Time.deltaTime;

        if(Timer > 0.5)
        {
            int ranSpawn = Random.Range(0,3);

            if(ranSpawn == 0)
            {

                Spawn = SpawnOne.transform.position;

            }

            if (ranSpawn == 1)
            {

                Spawn = SpawnTwo.transform.position;

            }

            if (ranSpawn == 2)
            {

                Spawn = SpawnThree.transform.position;

            }

            if (ranSpawn == 3)
            {

                Spawn = SpawnFour.transform.position;

            }
            Instantiate(Obstacle, Spawn, Quaternion.identity);

            Timer = 0;

        }


	}



}
