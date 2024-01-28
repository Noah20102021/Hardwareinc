using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraSteuerun : MonoBehaviour
{
    public Rigidbody2D CameraRiG;
    public float Speed;
    public float zoomsize = 17;
    public GameObject Cam;
    public float rot = 0;
    // Start is called before the first frame update
    void Start()
    {
        Speed = 30;
        zoomsize = 17;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90+rot));
            rot = rot + 90;
        }
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

        if (Input.GetAxis("Mouse ScrollWheel") > 0 && !Input.GetKey(KeyCode.LeftControl)) 
        {
            if (zoomsize > 2)
            {
                zoomsize -= 1;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0 && !Input.GetKey(KeyCode.LeftControl))
        {
            if (zoomsize < 200)
            {
                zoomsize += 1;
            }
        }
        GetComponent<Camera>().orthographicSize = zoomsize;

        if (Input.GetAxis("Mouse ScrollWheel") < 0 && Input.GetKey(KeyCode.LeftControl))
        {
            if (Speed > 1)
            {
                Speed -= 1;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0 && Input.GetKey(KeyCode.LeftControl))
        {
            if (Speed < 100)
            {
                Speed += 1;
            }
        }
    }
}
