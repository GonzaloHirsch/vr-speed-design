using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Framework.MonoBehaviorSingleton<GameManager>
{
    // Time the player has to pop all balloons, in seconds
    public float timeLimit = 90f;
    private float startTime = 0f;
    private bool gameStarted = false;
    private bool gameFinished = false;

    void Start () {
        // Start by disabling all the balloons until you hit play and resetting the score
        BalloonManager.Instance.DisableAll();
        Score.Instance.ResetScore();
    }

    void Update()
    {
        this.CheckGameOver();
    }

    public void StartGame()
    {
        Score.Instance.ResetScore();    // Reset the score
        this.gameStarted = true;
        this.gameFinished = false;
        this.startTime = Time.time;
        BalloonManager.Instance.EnableAll();    // Enable all balloons
    }

    public void ResetGame() {
        Score.Instance.ResetScore();
        this.gameStarted = true;
        this.gameFinished = false;
        this.startTime = Time.time;
        BalloonManager.Instance.EnableAll();    // Enable all balloons
    }

    private void CheckGameOver()
    {
        // Elapsed time is more than the limit, game is over
        // Balloons should be disabled in order to prevent the player from popping more
        if (this.gameStarted && !this.gameFinished && Time.time - this.startTime >= this.timeLimit)
        {
            BalloonManager.Instance.DisableAll();   // Disable all balloons
            this.gameFinished = true;
        }
    }
}
