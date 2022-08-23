using UnityEngine;

public class TimeSoundManager : Framework.MonoBehaviorSingleton<TimeSoundManager>
{
    private AudioSource audioSource;
    public float initialPitch = 1f;
    public float finalPitch = 2f;
    private float totalTime = 0f;

    void Start()
    {
        this.audioSource = GetComponent<AudioSource>();
        this.totalTime = GameManager.Instance.timeLimit;
    }


    void Update()
    {
        if (this.audioSource.isPlaying)
        {
            this.audioSource.pitch = Mathf.Clamp(GameManager.Instance.GetElapsedTime() / this.totalTime + this.initialPitch, this.initialPitch, this.finalPitch);
        }
    }

    public void StartSound()
    {
        this.audioSource.Play();
        this.audioSource.pitch = this.initialPitch;
    }

    public void StopSound()
    {
        this.audioSource.Stop();
        this.audioSource.pitch = this.initialPitch;
    }
}
