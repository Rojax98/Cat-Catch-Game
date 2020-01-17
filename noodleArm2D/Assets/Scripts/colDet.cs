using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colDet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("hit: " + collision.gameObject.name);

        if (collision.gameObject.tag == "Lose")
        {

            collision.gameObject.GetComponent<lose>().lost = true;


        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("hit: " + collision.gameObject.name);

        if (collision.gameObject.tag == "Lose")
        {

            collision.gameObject.GetComponent<lose>().lost = true;


        }

    }
}
