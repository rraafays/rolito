using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float movement_speed = 5;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = transform.position + (Vector3.left * movement_speed) * Time.deltaTime;
    }
}
