using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvanceOnZ : MonoBehaviour
{
    public float speed = 0.1f;
    public float limit = 50f;

    private Vector3 _initialPosition;
    void Start()
    {
        _initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > limit)
        {
            transform.position = _initialPosition;
        }

        transform.position += new Vector3(0, 0, speed);
    }
}
