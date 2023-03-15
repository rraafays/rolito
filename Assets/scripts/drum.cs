using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class drum : MonoBehaviour
{
  [SerializeField] private AudioSource audio_source;
  public AudioClip perfect_pata;
  public AudioClip good_pata;
  public AudioClip bad_pata;
  private float perfect_window;
  private float second = 0.1f;
  private bool expect = false;

  private void Start()
  {
  }

  private void Update()
  {
    if(expect)
    {
      second -= Time.smoothDeltaTime;
      if (second >= 0)
      {
        if (Input.GetKeyDown(KeyCode.F) == true) { audio_source.PlayOneShot(perfect_pata); }
      }
      else
      {
        second = 0.1f;
        expect = false;
      }
    }
  }

  public void expect_pata()
  {
    expect = true;
    if (Input.GetKey(KeyCode.F) == true) { audio_source.PlayOneShot(perfect_pata); }
  }
}
