using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class drum : MonoBehaviour
{
  [SerializeField] private AudioSource audio_source;
  public AudioClip pata;
  private float perfect_window;
  private float perfect = 0.1f;
  private bool expect = false;

  private void Start()
  {
  }

  private void Update()
  {
    if(expect)
    {
      perfect -= Time.smoothDeltaTime;
      if(perfect >= 0)
      {
        Debug.Log(perfect);
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
          audio_source.PlayOneShot(pata);
        }
      }
      else
      {
        perfect = 0.1f;
        expect = false;
      }
    }
  }

  public void expect_pata()
  {
    expect = true;
  }
}
