using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyAI : MonoBehaviour
{

    float rotationSpeed = 0;
    public float speed = 5;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rotationSpeed += Random.Range(-.5f, .5f);
        rotationSpeed = Mathf.Clamp(rotationSpeed, -1, 1);
        GetComponent<Rigidbody>().AddForce(-transform.right * speed);
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y + rotationSpeed, 0);
    }
}
