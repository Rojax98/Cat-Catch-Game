using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armPointsLeft : MonoBehaviour {

    [SerializeField]

    public GameObject[] RightArm;


    [SerializeField]
    public Vector3[] armP;
    [SerializeField]
    public Vector2[] colPoints;

    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void FixedUpdate()
    {


        //RightArm = GameObject.FindGameObjectsWithTag("rArm");

        float length = 14f;

        for (int i = 0; i < length; i++)
        {

            armP[i] = new Vector3(RightArm[i].transform.position.x, RightArm[i].transform.position.y, 0);


        }


        float lengthC = 13f;

        for (int i = 0; i < lengthC; i++)
        {


            colPoints[i] = new Vector2(RightArm[i].transform.position.x, RightArm[i].transform.position.y);
        }
    }
}
