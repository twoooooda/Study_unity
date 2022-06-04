using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShereController : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    public GameObject particle;
    public AudioClip breaksound;
    public GameObject scoreManager;
    private ScoreManager script;

    void Start()
    {
        //Rigidbodyを取得し、初速を与える
        rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(0.2f, 0, 0.2f) * 3);
        script = scoreManager.GetComponent<ScoreManager>();
    }

    void Update()
    {
        //Ballの速度を一定に保つ
        rb.velocity = rb.velocity.normalized * speed;
    }

    //衝突した瞬間に一度呼ばれる
    void OnCollisionEnter(Collision collision)
    {
        //当たった相手のタグがblockかどうか判定
        if (collision.gameObject.tag == "block")
        {
            //particleを発生させる
            Instantiate(particle, collision.transform.position, Quaternion.identity);
            //効果音を鳴らす
            AudioSource.PlayClipAtPoint(breaksound, collision.transform.position);
            script.AddScore();
        }
    }
}
