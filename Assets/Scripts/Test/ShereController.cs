using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShereController : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    public GameObject particle;
    private ParticleSystem particlesystem;
    // Start is called before the first frame update
    void Start()
    {
        particlesystem = particle.GetComponent<ParticleSystem>();
        rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(0.2f, 0, 0.2f) * 3);
    }

    // Update is called once per frame
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
