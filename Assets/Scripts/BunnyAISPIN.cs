using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyAISpin : MonoBehaviour
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
        rotationSpeed += Random.Range(-2, 2);
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y + rotationSpeed, 0);
    }
}
