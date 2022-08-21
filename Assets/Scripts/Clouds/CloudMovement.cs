using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    public float velocityMax = 15f;
    public float velocityMin = 5f;
    public float maxDistance = 50f;
    public Vector3 direction = new Vector3(1, 0, 0);
    private float velocity;
    private float newPos;
    private Vector3 startPos;
    
    void Start()
    {
        this.velocity = Random.Range(this.velocityMin, this.velocityMax) * (Random.Range(0f, 1f) > 0.5 ? 1 : -1);
        this.startPos = this.transform.position;
    }

    void Update()
    {
        this.newPos = Mathf.Sin(Time.time * this.velocity) * this.maxDistance;
        transform.position = this.startPos + this.direction * this.newPos;
    }
}
