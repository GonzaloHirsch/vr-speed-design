using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpAndDown : MonoBehaviour
{
    private Vector3 initialPosition;
    
    public float speed = 5f;
    public float height = 0.5f;

    private void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        float newY = Mathf.Sin(Time.time * speed);
        transform.position = initialPosition + new Vector3(0, newY, 0) ;
    }
}
