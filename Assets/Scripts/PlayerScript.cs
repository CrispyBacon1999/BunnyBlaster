using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody body;
    private Transform gun;
    private Animation gunAnimation;
    private AudioSource gunShotAudioSource;
    public AudioClip gunShotAudioClip;
    Quaternion rotationAngle = new Quaternion();
    public float speed = 1f;
    float rotationSpeed = 2.5f;

    private void Start()
    {
        this.body = this.GetComponent<Rigidbody>();
        this.gun = this.transform.GetChild(1);
        this.gunAnimation = this.gun.GetComponent<Animation>();
        this.gunShotAudioSource = this.gun.GetComponent<AudioSource>();
        StartCoroutine(Loop());
    }

    // Update both CountsPerSecond values every second.
    IEnumerator Loop()
    {
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                this.gunAnimation.Play("GunRecoil");
                this.gunShotAudioSource.PlayOneShot(this.gunShotAudioClip);
            }
            yield return 1;
        }
    }

    private void FixedUpdate()
    {
        this.Controls();
    }

    private void Controls()
    {
        float rotation = 0;
        Vector3 move = body.position;

        if (Input.anyKey)
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

            if (Input.GetKey(KeyCode.Space))
                this.Shoot();
        }

        //apply friction
        body.MovePosition(move);
        rotationAngle = Quaternion.Euler(0, rotationAngle.eulerAngles.y + rotation, 0);
        transform.rotation = rotationAngle;
    }

    private void Shoot()
    {
        RaycastHit hit;
        // Shoots a ray from the gun, if the collider it hits is on layer 6, the "enemies" layer, it will be destroyed
        if (Physics.Raycast(this.gun.transform.position, this.gun.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, 1 << 6))
        {
            Debug.DrawRay(this.gun.transform.position, this.gun.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Destroy(hit.collider.gameObject);
        }
    }
}
