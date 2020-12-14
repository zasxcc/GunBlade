using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneManager : MonoBehaviour
{
    public string sceneName_Start = "";
    public string sceneName_HighScore = "";

    public void OnClickButton_Start()
    {
        Debug.Log("TitleSceneManager.OnClickButton_Start() is Called");
        SceneManager.LoadScene(sceneName_Start);
    }

    public void OnClickButton_HighScore()
    {
        Debug.Log("TitleSceneManager.OnClickButton_HighScore() is Called");
        SceneManager.LoadScene(sceneName_HighScore);
    }

    public void OnClickButton_Exit()
    {
        Debug.Log("TitleSceneManager.OnClickButton_Exit() is Called");
        Application.Quit();
    }
}