using UnityEngine;
using UnityEngine.UI;

public class TimeManager : Framework.MonoBehaviorSingleton<TimeManager>
{
    public Text timeText;
    private string baseText = "Time Left: ";

    void Start()
    {
        this.timeText.text = baseText + this.GetTimeString();
    }

    void Update()
    {
        if (GameManager.Instance.IsGamePlaying()) {
            this.timeText.text = baseText + this.GetTimeString();
        }
    }

    private string GetTimeString() {
        string s = this.GetRoundedTime().ToString();
        return s.Length >= 5 ? s.Substring(0, 5) : s;
    }

    private float GetRoundedTime() {
        return Mathf.Round(GameManager.Instance.GetTimeLeft() * 10.0f) * 0.1f;
    }
}
