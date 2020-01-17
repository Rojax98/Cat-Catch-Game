using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class points : MonoBehaviour {

    LineRenderer lr;

    public GameObject armP;

    [SerializeField]
   public Vector3[] positions;



	// Use this for initialization
	void Start () {
  
        lr = GetComponent<LineRenderer>();
       
	}
	
	// Update is called once per frame
	void Update () {
        positions = armP.GetComponent<armPoints>().armP;

        lr.SetPositions(positions);
		
	}
}
