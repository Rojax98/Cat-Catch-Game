using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lineCol : MonoBehaviour {

    Collider2D EC;

    public GameObject armP;

    [SerializeField]
    public Vector2[] positions;


	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void FixedUpdate () {

        positions = armP.GetComponent<armPoints>().colPoints;

        float length = 13f;

        for (int i = 0; i < length; i++)
        {
            positions[i] = transform.InverseTransformPoint(positions[i]);


        }


        GetComponent<EdgeCollider2D>().points = positions;

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ignore")
        {

            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }

    }
}
