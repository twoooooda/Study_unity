using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarController : MonoBehaviour
{
    Rigidbody rb;
    public float power;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //キーを離したときにバーを止める
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            rb.velocity = Vector3.zero;
        }

        //矢印キー左右でバーを移動
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //rb.AddForce(new Vector3(1, 0, 0) * Time.deltaTime);
            rb.velocity = Vector3.right * power * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //rb.AddForce(new Vector3(-1, 0, 0) * power * Time.deltaTime);
            rb.velocity = Vector3.left * power * Time.deltaTime;
        }
    }
}
