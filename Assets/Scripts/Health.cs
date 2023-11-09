using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject particle;
    public int particleCount;
    public int hp;

    public void Damage()
    {
        hp--;
        if (hp <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);

        for (int i = 0; i < particleCount; i++)
        {
            var offset = Random.insideUnitSphere;
            Instantiate(particle, transform.position + offset, transform.rotation);
        }
    }
}
