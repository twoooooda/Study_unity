using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject PausePanel;
    private bool isPaused;

    void Start()
    {
        isPaused = false;
        Time.timeScale = 1;
    }

    void Update()
    {
        //escキーを押したときの処理
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused) Pause();

            else Resume();
        }
    }

    //ポーズ
    public void Pause()
    {
        //時間を止めてポーズメニューを出す
        Time.timeScale = 0;
        isPaused = true;
        PausePanel.SetActive(true);
    }

    //再開
    public void Resume()
    {
        Time.timeScale = 1;
        isPaused = false;
        PausePanel.SetActive(false);
    }

    //現在のSceneをリロード
    public void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //TitleSceneに遷移
    public void BackToTiltle()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
