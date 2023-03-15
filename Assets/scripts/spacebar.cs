using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spacebar : MonoBehaviour
{
  [SerializeField] bool use_test_beat;
  [SerializeField] float beat_size = 1.15f;
  [SerializeField] float return_speed = 5f;
  public Rigidbody2D body;
  private Vector3 start_size;
  private float perfect;

  void Start()
  {
    perfect = transform.localScale.y;
    start_size = transform.localScale;
    if (use_test_beat) { StartCoroutine(test_beat()); }
  }

  void Update() 
  { 
    transform.localScale = Vector3.Lerp(transform.localScale, start_size, Time.deltaTime * return_speed); 
    if (Input.GetKeyDown(KeyCode.Space) == true)
    {
      body.velocity = Vector2.up * 3;
    }
  }

  public void beat() 
  { 
    transform.localScale = new Vector3(0, 1, 0) * beat_size; 
  }

  IEnumerator test_beat()
  {
    while (true)
    {
      yield return new WaitForSeconds(1f);
      beat();
    }
  }
}
