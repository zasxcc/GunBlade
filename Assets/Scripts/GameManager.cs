using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Text scoreText;
    public int score = 0;
    public int enemyCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        //자신 체크
        if (!instance) 
            instance = this;

        scoreText.text = "Score : " + score;
    }

    public void AddScore(int num)
    {
        enemyCount++;
        score += num; 
        scoreText.text = "Score : " + score;
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
