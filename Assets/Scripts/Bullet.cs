using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20;
    //public KeyCode shootKey;

    private void Start()
    {
        Destroy(gameObject, 2f);
        //audioSource.PlayOneShot(pew);
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
        }
    }
}
