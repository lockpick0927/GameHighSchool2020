using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float M_Speed = 20.0f;
    public int Times = 150; //초당 30
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rigidbody = /*gameObject.*/GetComponent<Rigidbody>();

        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");
        rigidbody.AddForce(new UnityEngine.Vector3(xAxis, 0, yAxis) * M_Speed);

        float FireAxis = Input.GetAxis("Fire1");
        
        Times--;
        /*
        if (FireAxis > Times)
        {
            Die();
        }
        */
        /*
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigidbody.AddForce(Vector3.left * M_Speed);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rigidbody.AddForce(Vector3.right * M_Speed);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rigidbody.AddForce(Vector3.forward * M_Speed);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            rigidbody.AddForce(Vector3.back * M_Speed);
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Die();
        }
        */
        
    }

    public void Die()
    {
        Debug.Log("사망");
        gameObject.SetActive(false);
    }
}
