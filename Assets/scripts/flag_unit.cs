using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flag_unit : MonoBehaviour
{
  [SerializeField] bool use_test_beat; 
  [SerializeField] float beat_size = 1.15f;
  [SerializeField] float return_speed = 5f;

  [SerializeField] private AudioSource audio_source;
  public AudioClip forward1;
  public AudioClip forward2;
  public AudioClip forward3;
  public AudioClip attack1;
  public AudioClip attack2;
  public AudioClip attack3;

  public Rigidbody2D body;
  private Vector3 start_size;

  void Start()
  {
    start_size = transform.localScale; // save the starting size
    if (use_test_beat) { StartCoroutine(test_beat()); } // check whether or not test beat is set
  }

  void Update() 
  { 
    transform.localScale = Vector3.Lerp(transform.localScale, start_size, Time.deltaTime * return_speed); // constantly return to size
  }

  public void beat() 
  { 
    transform.localScale = start_size * beat_size; // on beat increase size
  }

  IEnumerator test_beat() // beat every second
  {
    while (true)
    {
      yield return new WaitForSeconds(1f);
      beat();
    }
  }

  // input actions
  public void perfect_forward() { audio_source.clip = forward3; audio_source.PlayDelayed(0.5f); }
  public void good_forward() { audio_source.clip = forward2; audio_source.PlayDelayed(0.5f); }
  public void bad_forward() { audio_source.clip = forward1; audio_source.PlayDelayed(0.5f); }
}
