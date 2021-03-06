using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    public GameObject particle;
    public AudioClip breaksound;
    public ScoreManager ScoreManager;

    void Start()
    {
        //Rigidbodyを取得し、初速を与える
        rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(0.2f, 0, 0.2f) * 3);
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
        if (collision.gameObject.tag == "Block")
        {
            //particleを発生させる
            Instantiate(particle, collision.transform.position, Quaternion.identity);
            //効果音を鳴らす
            AudioSource.PlayClipAtPoint(breaksound, collision.transform.position);
            //scoreを加算する
            ScoreManager.AddScore();
        }
    }

    //BallをActiveにしたりしなかったりする関数
    public void BallActivate(bool state)
    {
        this.gameObject.SetActive(state);
    }
}
