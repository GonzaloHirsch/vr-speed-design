using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleAround : MonoBehaviour
{
    public float rotateSpeed = 5f;
    public float radius = 0.1f;
    public bool debug = true;

    private Vector3 centre;
    private float angle;

    private void Start()
    {
        centre = transform.position;
    }

    private void Update()
    {
        angle += rotateSpeed * Time.deltaTime;
        var offset = new Vector3(Mathf.Sin(angle), 0, Mathf.Cos(angle)) * radius;
        transform.position = centre + offset;
    }

    // Debug, dibuja un circulo por donde va a viajar
    void OnDrawGizmos()
    {
        if (this.debug)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(Vector3.Equals(Vector3.zero, this.centre) ? transform.position : this.centre, this.radius);
        }
    }
}
