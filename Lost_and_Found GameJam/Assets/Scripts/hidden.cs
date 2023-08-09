using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hidden : MonoBehaviour
{
    
    public GameObject trapOne;
    
    public GameObject trapTwo;
   

    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag== "Player")
        {
            trapOne.SetActive(true);
            trapTwo.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            trapOne.SetActive(false);
            trapTwo.SetActive(false);
        }
    }
    
    /*
    void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            trapOne.SetActive(true);
        }

        if (Input.GetKeyUp(KeyCode.F))
        {
            trapOne.SetActive(false);
        }
    }*/
}
