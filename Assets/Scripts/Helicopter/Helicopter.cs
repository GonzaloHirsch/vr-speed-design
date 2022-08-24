using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour
{
    // Start is called before the first frame update
    private List<Vector3> _positions;
    private List<Vector3> _angles;
    private int _currentTarget;
    private bool _isRotating = false;
    private Vector3 _initialAngle;
    private Vector3 _prevAngle;

    void Start()
    {
        Vector3 initialPos = transform.position;

        _prevAngle = transform.rotation.eulerAngles;

        List<Vector3> points = new List<Vector3>
        {
            new Vector3(0, 10, 0),
            new Vector3(-150, -30, 0),
            new Vector3(0, -10, 150),
            new Vector3(110, -100, 0),
            new Vector3(40, 170, 0),
            new Vector3(0, 0, -150),
        };

        _positions = new List<Vector3>();
        _angles = new List<Vector3>
        {
            new Vector3(0,0, 0),
            new Vector3(0,0, 0),
            new Vector3(0, 90,0),
            new Vector3(0, 90, 0),
            new Vector3(0, 0, 0),
            new Vector3(0, 90, 0),
            new Vector3(0,90,0)
        };

        Vector3 prevPoint = initialPos;

        for (int i = 0; i < points.Count; i++)
        {
            _positions.Add(prevPoint + points[i]);
            prevPoint = _positions[i];
        }

        _positions.Add(initialPos);

        _currentTarget = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isRotating)
        {
            moveToNextAngle();
        }else
        {
            moveToNextPosition();
        }
    }

    private void addPosition(Vector3 position)
    {
        
    }

    private void moveToNextPosition()
    {
        var step = 25 * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, _positions[_currentTarget], step);
        if (Vector3.Distance(transform.position, _positions[_currentTarget]) < 0.001f)
        {
            _currentTarget = (_currentTarget + 1) % _positions.Count;
            _isRotating = true;
        }
    }
    private void moveToNextAngle()
    {

        transform.Rotate(0.5f*Time.deltaTime * _angles[_currentTarget]);
        float x = transform.rotation.eulerAngles[0];
        float y = transform.rotation.eulerAngles[1];
        float z = transform.rotation.eulerAngles[2];
        x = x > 180 ? (x - 360) : x;
        y = y > 180 ? (y - 360) : y;
        z = z > 180 ? (z - 360) : z;
        Vector3 newAngle = new Vector3(x, y, z);
        Vector3 targetAngle =_prevAngle + _angles[_currentTarget];
        targetAngle.x = targetAngle.x > 180 ? (targetAngle.x - 360) : targetAngle.x;
        targetAngle.y = targetAngle.y > 180 ? (targetAngle.y - 360) : targetAngle.y;
        targetAngle.z = targetAngle.z > 180 ? (targetAngle.z - 360) : targetAngle.z;
        Debug.Log(newAngle);
        if (Vector3.Distance(newAngle, targetAngle)< 1f)
        {
            _isRotating = false;
            _prevAngle = newAngle;
        }


    }
}