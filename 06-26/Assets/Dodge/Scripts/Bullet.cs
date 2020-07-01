using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Tick;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rigidbody = /*gameObject.*/GetComponent<Rigidbody>();

        rigidbody.AddForce(transform.forward * 10) ;
        Tick += Time.deltaTime;
        Debug.Log(Tick);
        if (Tick > 5)
        {
            gameObject.SetActive(false);
            Tick = 0;

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        var player = other.attachedRigidbody.GetComponent<PlayerController>();
        if (other.attachedRigidbody.tag == "Player")
        {
            player.Die();
        }

    }
}
