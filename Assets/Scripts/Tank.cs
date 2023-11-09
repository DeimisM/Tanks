using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.UIElements;

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

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        var ver = Input.GetAxis(vertical);
        transform.position += transform.forward * speed * ver * Time.deltaTime;

        var hor = Input.GetAxis(horizontal);
        transform.Rotate(0, rotateSpeed * hor * Time.deltaTime, 0);

        if (Input.GetKey(shootKey))
        {
            //print("bum");
            Instantiate(bullet, shootPoint.position, transform.rotation);

            if (!audioSource.isPlaying)
            {
                audioSource.clip = shooting;
                audioSource.Play();
            }
        }

        else
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Boom")
        {
            //Destroy(collision.gameObject);          // istrina ka priliete
            collision.gameObject.GetComponent<Health>().Ram();
        }
    }
}
