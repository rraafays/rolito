using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy_self : MonoBehaviour
{
  public GameObject self;
  public Rigidbody2D body;

  private Vector3 start_size;
  [SerializeField] float beat_size = 1.15f;
  [SerializeField] float return_speed = 5f;

  void Start()
  {
    Destroy(self, 0.5f);
    start_size = transform.localScale;
    transform.localScale = start_size * beat_size; 
  }

  void Update() 
  { 
    transform.localScale = Vector3.Lerp(transform.localScale, start_size, Time.deltaTime * return_speed); 
  }
}
