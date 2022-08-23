using UnityEngine;

public class GameManager : Framework.MonoBehaviorSingleton<GameManager>
{
    // Time the player has to pop all balloons, in seconds
    public float timeLimit = 90f;
    private float startTime = 0f;
    private bool gameStarted = false;
    private bool gameFinished = false;
    private float elapsedTime = 0f;

    void Start()
    {
        this.SetupGame();
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
        TimeSoundManager.Instance.StartSound(); // Start ticking sound
    }

    public void ResetGame()
    {
        this.StartGame();
    }

    public void SetupGame()
    {
        // Start by disabling all the balloons until you hit play and resetting the score
        BalloonManager.Instance.DisableAll();
        this.gameStarted = false;
        this.gameFinished = false;
        this.startTime = 0f;
        Score.Instance.ResetScore();
    }

    public float GetTimeLeft()
    {
        return this.gameStarted ? this.timeLimit - this.elapsedTime : this.timeLimit;
    }
    
    public float GetElapsedTime()
    {
        return this.gameStarted ? this.elapsedTime : 0f;
    }

    public bool IsGamePlaying()
    {
        return this.gameStarted && !this.gameFinished;
    }

    private void CheckGameOver()
    {
        // Elapsed time is more than the limit, game is over
        // Balloons should be disabled in order to prevent the player from popping more
        this.elapsedTime = Time.time - this.startTime;
        if (this.IsGamePlaying() && this.elapsedTime >= this.timeLimit)
        {
            BalloonManager.Instance.DisableAll();   // Disable all balloons
            this.gameFinished = true;
            TimeSoundManager.Instance.StopSound(); // Stop ticking sound
        }
    }
}
