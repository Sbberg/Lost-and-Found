using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushPlat : MonoBehaviour
{
    public Rigidbody2D body;
    public float left;
    public float right;
    public float velThresh;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.angularVelocity = velThresh;
    }

    // Update is called once per frame
    void Update()
    {
        Push();
    }

    public void Push()
    {
        if (transform.rotation.z > 0 && transform.rotation.z < right && (body.angularVelocity > 0) && body.angularVelocity < velThresh)
        {
            body.angularVelocity = velThresh;
        }
        else if (transform.rotation.z < 0 && transform.rotation.z > left && (body.angularVelocity < 0) && body.angularVelocity > velThresh * -1)
        {
            body.angularVelocity = velThresh * -1;
        }
    }
}
