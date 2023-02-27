using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    private float MovementSpeed = 200.0f;
    private Collider collider;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(transform.forward * MovementSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Destroyed");
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }  
    }
}
