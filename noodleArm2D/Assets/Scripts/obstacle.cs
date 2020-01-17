using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour {

    GameObject[] Obstacles;
        
    Rigidbody2D rb;

    float lifeCount;

    bool hit;
	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody2D>();

        transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));

        Obstacles = GameObject.FindGameObjectsWithTag("Obstacle");

	}
	
	// Update is called once per frame
	void FixedUpdate () {

        Vector2 Center = new Vector2(0, 0);

        lifeCount += 1 * Time.deltaTime;


        if (Vector2.Distance(transform.position, Center)  > 60 )
        {

            Destroy(gameObject);
        }

      
        for (int i = 0; i < Obstacles.Length; i++)
        {

            

        }

        if(rb.velocity.x > 5f )
        {

            rb.velocity = new Vector2(10f, rb.velocity.y);

        }

        if (rb.velocity.y > 5f)
        {

            rb.velocity = new Vector2(rb.velocity.x, 5f);

        }


        if (hit == false)
        {
            rb.velocity = transform.right * 3f;
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Obstacle")
        {

            hit = true;

            Vector3 normal = collision.contacts[0].normal;

            Vector3 Vel = rb.velocity;

            rb.velocity = Vector3.Reflect(Vel, normal) * 2f;

            //print("Reflect" + Vector3.Reflect(Vel, normal));
        }
    }


}
