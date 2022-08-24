using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{

    public GameObject follow;

    private Vector3 relativePosition;

    private void OnEnable()
    {
        transform.position = follow.transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        relativePosition = follow.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = follow.transform.position - relativePosition;
    }
}
