using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSide : MonoBehaviour
{
    public GameObject player;
    private Vector3 camPos;
    // Start is called before the first frame update
    void Start()
    {
        camPos = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
    }
}

