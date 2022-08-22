using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToCoordinate : MonoBehaviour
{
    public float speed = 0.01f;

    public Vector3 target;

    private Vector3 _initialPosition;
    private bool _movesOnX = false;
    private bool _movesOnY = false;
    private bool _movesOnZ = false;

    private const double TOLERANCE = 0.1;

    void Start()
    {
        _initialPosition = transform.position;

        if (Math.Abs(_initialPosition.x - target.x) > TOLERANCE)
        {
            _movesOnX = true;
        }
        if (Math.Abs(_initialPosition.y - target.y) > TOLERANCE)
        {
            _movesOnY = true;
        }
        if (Math.Abs(_initialPosition.z - target.z) > TOLERANCE)
        {
            _movesOnZ = true;
        }
    }

    void Update()
    {
        if (_movesOnX)
        {
            transform.position += new Vector3(speed, 0, 0);

            if (Math.Abs(target.x - transform.position.x) < TOLERANCE)
            {
                _movesOnX = false;
            }

        }
        if (_movesOnY)
        {
            transform.position += new Vector3(0, speed, 0);

            if (Math.Abs(target.y - transform.position.y) < TOLERANCE)
            {
                _movesOnY = false;
            }

        }
        if (_movesOnZ)
        {
            transform.position += new Vector3(0, 0, speed);

            if (Math.Abs(target.z - transform.position.z) < TOLERANCE)
            {
                _movesOnZ = false;
            }

        }

        if (!_movesOnX && !_movesOnY && !_movesOnZ)
        {
            transform.position = _initialPosition;
            if (Math.Abs(_initialPosition.x - target.x) > TOLERANCE)
            {
                _movesOnX = true;
            }
            if (Math.Abs(_initialPosition.y - target.y) > TOLERANCE)
            {
                _movesOnY = true;
            }
            if (Math.Abs(_initialPosition.z - target.z) > TOLERANCE)
            {
                _movesOnZ = true;
            }
        }

    }
}
