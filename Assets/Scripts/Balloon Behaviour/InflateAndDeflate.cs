using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InflateAndDeflate : MonoBehaviour
{
    private Vector3 initialScale;
    public float scaleFrecuency = 0.5f;

    private void Start()
    {
        initialScale = transform.localScale;
    }

    void Update()
    {
        float s = Mathf.Cos(2 * Mathf.PI  * Time.time * scaleFrecuency);
        transform.localScale = initialScale + new Vector3( initialScale.x + s,initialScale.y +s,initialScale.z +s);
    }
}
