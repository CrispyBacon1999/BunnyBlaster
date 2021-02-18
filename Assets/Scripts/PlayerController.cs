using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    float speed = 10f;
    float rotationSpeed = 1;
    Quaternion rotationAngle = new Quaternion();


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float rotation = 0;
        Vector3 force = new Vector3();
        Rigidbody body = GetComponent<Rigidbody>();
        if(Input.GetKey(KeyCode.W)) {
            body.velocity = transform.forward * speed;
        }
        else if(Input.GetKey(KeyCode.S)) {
            body.velocity = -transform.forward * speed;
        }
        else if(Input.GetKey(KeyCode.A)) {
            body.velocity = -transform.right * speed;
        }
        else if(Input.GetKey(KeyCode.D)) {
            body.velocity = transform.right * speed;
        }
        else {
            body.velocity = new Vector3(0, body.velocity.y, 0);
        }

        if(Input.GetKey(KeyCode.RightArrow)) {
            rotation = 1;
        }
        else if(Input.GetKey(KeyCode.LeftArrow)) {
            rotation = -1;
        } else {
            rotation = 0;
        }
        
        // force.y = body.velocity.y;
        // body.velocity = transform.forward * force;
        rotationAngle = Quaternion.Euler(0, rotationAngle.eulerAngles.y + rotation, 0);
        transform.rotation = rotationAngle;
    }
}
