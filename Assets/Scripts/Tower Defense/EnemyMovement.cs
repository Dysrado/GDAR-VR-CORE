using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float MovementSpeed = 1.0f;
    private Collider collider;
    private Rigidbody rb;

    private TowerDefense TD;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
        TD = GameObject.FindObjectOfType<TowerDefense>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(Vector3.back * MovementSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Turret"))
        {
            Debug.Log("Destroyed");
            Destroy(this.gameObject);
            TD.PlayerDamaged();
        }  
    }
    
}
