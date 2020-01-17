using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oceanScale : MonoBehaviour
{
    public GameObject camRef;

    public float Scale;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

       Scale = camRef.GetComponent<zoom>().scale;

        transform.localScale = new Vector3(162f * Scale,64,67);
        
    }
}
