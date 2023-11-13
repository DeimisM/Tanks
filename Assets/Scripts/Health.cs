using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject particle;
    public int particleCount;
    public int hp;

    AudioSource audioSource;
    public AudioClip explosion;
    public AudioClip hit;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Damage()
    {
        audioSource.PlayOneShot(hit);
        hp--;
        if (hp <= 0)
        {
            Die();
        }
    }

    public void Ram()
    {
        audioSource.PlayOneShot(hit);
        hp -= 30;
        if (hp <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        audioSource.clip = explosion;
        audioSource.PlayOneShot(explosion);

        for (int i = 0; i < particleCount; i++)
        {
            var offset = Random.insideUnitSphere;
            Instantiate(particle, transform.position + offset, transform.rotation);
        }

        Destroy(gameObject);
    }
}
