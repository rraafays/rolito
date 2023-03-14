using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class berd : MonoBehaviour
{
    public Rigidbody2D body;
    public float flap_strength;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true) { body.velocity = Vector2.up * flap_strength; }
        
    }
}
