using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    public float speed = 5;
    public float rotateSpeed = 90;

    public string vertical;
    public string horizontal;

    public KeyCode shootKey;

    public GameObject bullet;
    public Transform shootPoint;

    AudioSource audioSource;
    public AudioClip shooting;
    public AudioClip engine;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Ensure there is an AudioSource component attached
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        var ver = Input.GetAxis(vertical);
        transform.position += transform.forward * speed * ver * Time.deltaTime;

        var hor = Input.GetAxis(horizontal);
        transform.Rotate(0, rotateSpeed * hor * Time.deltaTime, 0);

        // Check if the tank is moving
        if (ver != 0 || hor != 0)
        {
            if (!audioSource.isPlaying)
            {
                // Play engine sound
                audioSource.clip = engine;
                audioSource.Play();
            }
        }
        else
        {
            // Tank is not moving, stop playing engine sound
            if (audioSource.isPlaying && audioSource.clip == engine)
            {
                audioSource.Stop();
            }
        }

        if (Input.GetKey(shootKey))
        {
            // Instantiate bullet and play shooting sound
            Instantiate(bullet, shootPoint.position, transform.rotation);

            if (!audioSource.isPlaying)
            {
                // Play shooting sound
                audioSource.clip = shooting;
                audioSource.Play();
            }
        }
        else
        {
            // Stop playing shooting sound
            if (audioSource.isPlaying && audioSource.clip == shooting)
            {
                audioSource.Stop();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Boom")
        {
            collision.gameObject.GetComponent<Health>().Ram();
        }
    }
}