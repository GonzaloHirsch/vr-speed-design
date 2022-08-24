using UnityEngine;

public class BladeController : MonoBehaviour
{
    public float speed = 10f;
    void Update()
    {
        transform.Rotate(0, this.speed * Time.deltaTime, 0);
    }
}
