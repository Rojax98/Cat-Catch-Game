using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointsLeft : MonoBehaviour {
    LineRenderer lr;

    public GameObject armP;

    [SerializeField]
    Vector3[] positions;



    // Use this for initialization
    void Start()
    {

        lr = GetComponent<LineRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        positions = armP.GetComponent<armPointsLeft>().armP;



        lr.SetPositions(positions);

    }
}
