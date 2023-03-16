using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy_self : MonoBehaviour
{
  public GameObject self; // take the current game object as param
  public Rigidbody2D body; // take the current rigid body

  private Vector3 start_size; // variable to store the start size
  [SerializeField] float beat_size = 1.15f; // default variable for expansion size
  [SerializeField] float return_speed = 5f; // default variable for return speed

  void Start()
  {
    Destroy(self, 0.5f); // immediately destroy self after half a second
    start_size = transform.localScale; // save the current size
    transform.localScale = start_size * beat_size; // expand
  }

  void Update() 
  { 
    transform.localScale = Vector3.Lerp(transform.localScale, start_size, Time.deltaTime * return_speed); // return to start size at a constant rate
  }
}
