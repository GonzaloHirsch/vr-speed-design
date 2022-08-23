using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarOscillation : MonoBehaviour
{
    public float speed = 5f;
    public float maxDistance = 210f;
    public Vector3 direction;
    private int moveDirection = 1;
    [SerializeField]
    private float currentDistance = 0f;
    private float frameDistance = 0f;
    private Vector3 initialRotation;
    private Vector3 rotationChange = new Vector3(0, 180, 0);

    void Start()
    {
        this.initialRotation = this.transform.rotation.eulerAngles;
    }

    void Update()
    {
        // Calculate distance moved in frame
        this.frameDistance = Time.deltaTime * this.speed;
        // Update position
        this.transform.position += this.frameDistance * this.moveDirection * this.direction;
        // Update total distance
        this.currentDistance += this.frameDistance;
        // If total distance greater than limit, go the other side
        if (this.currentDistance >= this.maxDistance)
        {
            this.currentDistance = 0f;
            this.moveDirection = -1 * this.moveDirection;
            // Also rotate the car for consistency
            this.transform.rotation = Quaternion.Euler(this.initialRotation + (this.moveDirection > 0 ? Vector3.zero : this.moveDirection * this.rotationChange));
        }
    }
}
