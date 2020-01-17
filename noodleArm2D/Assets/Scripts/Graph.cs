using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{


    public GameObject End;
    public GameObject Point;

    int points = 20;
    [SerializeField]
    GameObject[] objects;
    [SerializeField]
    Vector3[] spawnPos;

    float distToEX;
    float distToEY;

    float counter = 0;

    Vector2 pos;
    Vector2 endPos;
    Vector3 placePos;

    bool spawn;


    // Use this for initialization
    void Start()
    {
        objects = new GameObject[points];
        spawnPos = new Vector3[points];
        for (int i = 0; i < points; i++)
        {
            objects[i] = Instantiate(Point, new Vector3(0, 0, 0), Quaternion.identity);
        }



    }

    // Update is called once per frame
    void Update()
    {

        pos = transform.position;
        endPos = End.transform.position;

            for (int i = 0; i < points; i++)
            {

                counter += 1f / points;

                placePos = pos + (endPos - pos) * counter;

                spawnPos[i] = new Vector3(placePos.x, placePos.y,0);

                
                objects[i].transform.position = new Vector3(spawnPos[i].x, spawnPos[i].y, 0);

            }


        counter = 0;
  
    }
}
