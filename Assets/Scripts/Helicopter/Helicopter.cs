using UnityEngine;

public class Helicopter : MonoBehaviour
{
    public Vector3[] positions;
    private int currentPosition = 0;
    public float speed = 10f;
    public float positionTolerance = 0.5f;
    private Vector3 newTargetPosition = Vector3.zero;

    void Update()
    {
        // Update the position, move to the target
        this.transform.position = Vector3.MoveTowards(this.transform.position, this.positions[this.currentPosition], Time.deltaTime * this.speed);
        // Near enough from the position, move to next one
        if (Vector3.Distance(this.transform.position, this.positions[this.currentPosition]) <= this.positionTolerance)
        {
            this.currentPosition = (this.currentPosition + 1) % this.positions.Length;
            // Look at the target
            this.newTargetPosition = this.positions[this.currentPosition];
            // Fix the y position to avoid rotations in x
            this.newTargetPosition.y = this.transform.position.y;
            this.transform.LookAt(newTargetPosition);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (this.positions != null)
        {
            foreach (Vector3 v in this.positions)
            {
                Gizmos.DrawSphere(v, 2f);
            }
        }
    }
}
