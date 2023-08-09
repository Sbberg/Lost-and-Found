using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject playercamPos;
    private Vector3 camPos;
    
    // Start is called before the first frame update
    void Start()
    {
        camPos = transform.position - playercamPos.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, playercamPos.transform.position.y , transform.position.z);
    }
}
