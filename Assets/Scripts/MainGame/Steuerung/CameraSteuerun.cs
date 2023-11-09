using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSteuerun : MonoBehaviour
{
    public Rigidbody2D CameraRiG;
    public float Speed;
    public float zoomsize = 17;
    // Start is called before the first frame update
    void Start()
    {
        Speed = 20;
        zoomsize = 17;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.W))
        {
            transform.position = new Vector3(transform.position.x, 
                transform.position.y + Time.deltaTime * Speed, transform.position.z);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector3(transform.position.x - Time.deltaTime * Speed,
                transform.position.y, transform.position.z);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position = new Vector3(transform.position.x,
                transform.position.y - Time.deltaTime * Speed, transform.position.z);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector3(transform.position.x + Time.deltaTime * Speed,
                transform.position.y, transform.position.z);
        }

        if(Input.GetAxis("Mouse ScrollWheel") > 0) 
        {
            if (zoomsize > 2)
            {
                zoomsize -= 1;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (zoomsize < 50)
            {
                zoomsize += 1;
            }
        }
        GetComponent<Camera>().orthographicSize = zoomsize;
    }
}
