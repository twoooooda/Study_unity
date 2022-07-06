using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public long point;
    public int timeLeft;
    private GameObject[] blocks;
    private int blocknum;
    private long score;
    private bool flag = true;
    public BallController BallController;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI CountDownText;

    void Start()
    {
        //ブロックの数を数える
        blocknum = GameObject.FindGameObjectsWithTag("Block").Length;
        //得点、表示初期化
        score = 0;
        scoreText.text = "score:0";
        timeText.text = "time:" + timeLeft.ToString();
        //コルーチン開始
        StartCoroutine(TimeManager(timeLeft));
    }

    void Update()
    {
        if (blocknum > 0)
        {
            //現在のスコアをテキストで表示
            scoreText.text = "Score:" + score;
        }
    }

    //時間管理のコルーチン
    private IEnumerator TimeManager(int timeLeft)
    {
        yield return new WaitForSeconds(0.2f);
        //開始前の３秒カウントダウン
        for (int i = 3; i > 0; i--)
        {
            CountDownText.text = i.ToString();
            yield return new WaitForSeconds(1.0f);
        }

        //ボール出現
        BallController.BallActivate(true);

        //スタートの文字を1秒出す
        CountDownText.text = "Start!";
        yield return new WaitForSeconds(1.0f);
        CountDownText.text = "";

        //ゲーム時間のカウントダウン開始
        for (; timeLeft > 0; timeLeft--)
        {
            //ブロックが全部なくなるとカウントダウン終了
            if (blocknum <= 0)
            {
                scoreText.text = "Score:" + score.ToString() + "+" + ((timeLeft).ToString()) + "*50" + "=" + (score + (timeLeft) * 50).ToString();
                CountDownText.text = "Game clear";
                timeText.text = "time:" + timeLeft.ToString();
                BallController.BallActivate(false);
                flag = false;
                break;
            }
            timeText.text = "time:" + timeLeft.ToString();
            yield return new WaitForSeconds(1.0f);

        }

        //ブロックが残っている状態で時間切れになったとき
        if (flag)
        {
            timeText.text = "time:0";
            CountDownText.text = "Stop!";
        }

        //制限時間切れたらボール消去
        BallController.BallActivate(false);
    }

    //外部スクリプトからスコアを加算する用の関数
    public void AddScore()
    {
        score += point;
        blocknum -= 1;
    }
}
