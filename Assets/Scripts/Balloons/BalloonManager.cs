public class BalloonManager : Framework.MonoBehaviorSingleton<BalloonManager>
{
    private Balloon[] balloons;

    void Start()
    {
        this.balloons = FindObjectsOfType<Balloon>();
    }

    public void EnableAll() {
        this.ChangeBalloonsState(true);
    }
    
    public void DisableAll() {
        this.ChangeBalloonsState(false);
    }

    private void ChangeBalloonsState(bool active) {
        foreach (Balloon b in this.balloons) b.gameObject.SetActive(active);
    }
}
