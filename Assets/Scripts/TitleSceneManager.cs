using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TitleSceneManager : MonoBehaviour
{
    //ゲーム開始の関数
    public void GameStart()
    {
        SceneManager.LoadScene("SampleScene");
    }

    //ゲーム終了の関数
    public void QuitGame()
    {
#if UNITY_EDITOR//Unity editorでのゲームプレイを終了
        UnityEditor.EditorApplication.isPlaying = false;
#else//ビルド後のゲームプレイ終了
            Application.Quit();
#endif
    }
}
