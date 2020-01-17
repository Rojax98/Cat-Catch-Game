using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamManager : MonoBehaviour
{

    public GameObject Player;
    public GameObject mainCam;
    public Camera catCam;
    public GameObject loseLine;

    
    // Start is called before the first frame update
    void Start()
    {

        catCam.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {

        if(mainCam.GetComponent<zoom>().scale > 13)
        {
            //catCam.enabled = true;
        }

        if(mainCam.GetComponent<zoom>().scale < 13 || loseLine.GetComponent<lose>().lost == true)
        {

            catCam.enabled = false;

        }
        
    }
}
