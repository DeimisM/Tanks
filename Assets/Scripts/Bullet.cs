using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 1000000;

    private void Start()
    {
        Destroy(gameObject, 2f);
    }
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);                    // istrina kulka prisilietus
        if(collision.gameObject.tag == "Boom")
        {
            //Destroy(collision.gameObject);          // istrina ka priliete
            collision.gameObject.GetComponent<Health>().Damage();
            print("die");
        }
    }
}
