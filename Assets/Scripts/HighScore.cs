using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighScore : MonoBehaviour
{
    private Text highScore;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        highScore = GetComponent<Text>();
        score = PlayerPrefs.GetInt("Score", default);
    }

    // Update is called once per frame
    void Update()
    {
        highScore.text = "HighScore : " + score;
    }
}
