using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShereController : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    public GameObject particle;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(0.2f, 0, 0.2f) * 3);
    }

    void Update()
    {
        rb.velocity = rb.velocity.normalized * speed;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "block")
        {
            Instantiate(particle, collision.transform.position, Quaternion.identity);
        }
    }
}
