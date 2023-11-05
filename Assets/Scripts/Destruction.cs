using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour
{
    public GameObject brokenRock;

    void OnCollisionEnter(Collision collision)
    {
        print("hit");
        Instantiate(brokenRock, transform.position, transform.rotation);
        Instantiate(brokenRock, transform.position, transform.rotation);
        Instantiate(brokenRock, transform.position, transform.rotation);
        Instantiate(brokenRock, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
