using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private int score;
    public int point;
    public GameObject ball;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI CountDownText;

    void Start()
    {
        //得点初期化
        score = 0;

        StartCoroutine(TimeManager());
    }

    void Update()
    {
        //現在のスコアをテキストで表示
        scoreText.text = "Score:" + score;
    }

    private IEnumerator TimeManager()
    {
        //最初に一瞬待つ
        yield return new WaitForSeconds(0.5f);

        //1秒間3を表示する
        CountDownText.text = "3";
        yield return new WaitForSeconds(1.0f);

        CountDownText.text = "2";
        yield return new WaitForSeconds(1.0f);

        CountDownText.text = "1";
        yield return new WaitForSeconds(1.0f);

        CountDownText.text = "Start!";
        ball.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        CountDownText.text = "";


    }
    //外部スクリプトからスコアを加算する用の関数
    public void AddScore()
    {
        score += point;
    }
}
