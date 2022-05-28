using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarCntroller : MonoBehaviour
{
    Rigidbody rb;
    public float power;
    private Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //矢印キー左右でバーを移動
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = Vector3.right * power * Time.deltaTime;
        }

        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = Vector3.left * power * Time.deltaTime;
        }

        else
        {
            rb.velocity = Vector3.zero;
        }

        pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -4, 4);
        transform.position = pos;
    }
}