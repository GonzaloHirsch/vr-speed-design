using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : Framework.MonoBehaviorSingleton<ScoreManager>
{
    public Text scoreText;
    private int previousScore = 0;

    void Start() {
        if (this.scoreText == null) Debug.LogError("[ScoreManager] Missing ScoreText Text property!");
    }

    void Update()
    {
        if (!Mathf.Approximately(this.previousScore, Score.Instance.GetScore())) {
            this.previousScore = Score.Instance.GetScore();
            this.scoreText.text = this.previousScore.ToString();
        }
    }
}
