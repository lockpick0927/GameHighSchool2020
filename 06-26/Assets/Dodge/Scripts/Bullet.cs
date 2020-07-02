using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Tick;
    
    void Update()
    {
        Rigidbody rigidbody = /*gameObject.*/GetComponent<Rigidbody>();

        rigidbody.AddForce(transform.forward * 10) ;
        Tick += Time.deltaTime;
        if (Tick > 3)
        {
            Destroy(gameObject);
            Tick = 0;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody != null && other.attachedRigidbody.tag == "Player")
        {
            var player = other.attachedRigidbody.GetComponent<PlayerController>();
            player.Die();
        }
    }
}
