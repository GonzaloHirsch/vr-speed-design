using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpAndDown : MonoBehaviour
{
    private Vector3 initialPosition;

    public float speed = 5f;
    public float height = 0.5f;
    public bool debug = true;

    private void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        float newY = Mathf.Sin(Time.time * speed) * this.height;
        transform.position = initialPosition + new Vector3(0, newY, 0);
    }

    // Debug, dibuja una recta por donde va a moverse
    void OnDrawGizmos()
    {
        if (this.debug)
        {
            Gizmos.color = Color.red;
            Vector3 v3height = new Vector3(0, this.height, 0);
            Vector3 pos = Vector3.Equals(Vector3.zero, this.initialPosition) ? transform.position : this.initialPosition;
            Gizmos.DrawLine(pos - v3height, pos + v3height);
        }
    }
}
