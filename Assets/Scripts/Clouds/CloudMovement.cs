using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    public float velocity;
    private Vector3 startPos;
    
    
    // Start is called before the first frame update
    void Start()
    {
        velocity = Random.Range(5f, 15F);
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position[0] > 300)
        {
            ResetCloud();
            return;
        }
        transform.position += velocity * new Vector3(Time.deltaTime, 0, 0);
    }

    private void ResetCloud()
    {
        velocity = Random.Range(5f, 15F);
        float newZ = Random.Range(-5f, 5f);
        if (transform.position[2] + newZ < 150)
        {
            newZ = -newZ;
        }
        transform.position = startPos + new Vector3(-500, 0, newZ);
    }
}
