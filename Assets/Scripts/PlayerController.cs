using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody body;
    Quaternion rotationAngle = new Quaternion();
    public float speed = 1f;
    float rotationSpeed = 2.5f;

    private void Start()
    {
        this.body = this.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        this.Controls();
    }

    private void Controls()
    {
        float rotation = 0;
        Vector3 move = body.position;
       
        if(Input.anyKey)
        {
            if (Input.GetKey(KeyCode.LeftShift))
                speed = speed * 2;

            if (Input.GetKey(KeyCode.W))
                move += transform.forward * speed;
            else if (Input.GetKey(KeyCode.S))
                move += -transform.forward * speed;

            if (Input.GetKey(KeyCode.A))
                move += -transform.right * speed;
            else if (Input.GetKey(KeyCode.D))
                move += transform.right * speed;

            if (Input.GetKey(KeyCode.RightArrow))
                rotation = rotationSpeed;
            else if (Input.GetKey(KeyCode.LeftArrow))
                rotation = -rotationSpeed;
            else
                rotation = 0;
        }

        //apply friction
        body.MovePosition(move);
        rotationAngle = Quaternion.Euler(0, rotationAngle.eulerAngles.y + rotation, 0);
        transform.rotation = rotationAngle;
    }
}
