using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPuzzle : MonoBehaviour
{
    public GameObject[] ballArray;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ballArray = GameObject.FindGameObjectsWithTag("Ball");
    }
}
