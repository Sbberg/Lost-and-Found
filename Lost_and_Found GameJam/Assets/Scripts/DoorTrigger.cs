using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public GameObject blockOne;
    public GameObject blockTwo;
    // Start is called before the first frame update
    void Start()
    {
        blockOne.SetActive(true);
        blockTwo.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Boulder") { 
        blockOne.SetActive(false);
        blockTwo.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Boulder")
        {
            blockOne.SetActive(true);
            blockTwo.SetActive(true);
        }
    }
}
