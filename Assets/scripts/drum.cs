using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class drum : MonoBehaviour
{
  [SerializeField] private AudioSource audio_source;
  [SerializeField] private UnityEvent beat;
  [SerializeField] private UnityEvent forward;

  private bool expect_perfect = false;
  private bool expect_good = false;
  private bool expect_bad = false;

  private float perfect_window = 0.1f;
  private float good_window = 0.3f;
  private float bad_window = 0.6f;

  private bool perfect_pata;
  private bool good_pata;
  private bool bad_pata;
  public AudioClip perfect_pata_sound;
  public AudioClip good_pata_sound;
  public AudioClip bad_pata_sound;

  public AudioClip perfect_pon_sound;
  public AudioClip good_pon_sound;
  public AudioClip bad_pon_sound;

  private string command = "";

  private void Start()
  {
  }

  private void Update()
  {
    if (command.Length > 4) { command = ""; }
    if (command.Length == 4)
    { 
      Debug.Log(command); 
      if (command == "FFFA") { forward.Invoke(); }

      command = ""; 
    }

    if (expect_perfect)
    {
      perfect_window -= Time.smoothDeltaTime;
      if (perfect_window >= 0) { expect_pata('p'); expect_pon('p'); return; }
      else { perfect_window = 0.1f; expect_perfect = false; expect_good = true; }
    }
    if (expect_good)
    {
      good_window -= Time.smoothDeltaTime;
      if (good_window >= 0) { expect_pata('g'); expect_pon('g'); return; }
      else { good_window = 0.3f; expect_good = false; expect_bad = true; }
    }
    if (expect_bad)
    {
      bad_window -= Time.smoothDeltaTime;
      if (bad_window >= 0) { expect_pata('b'); expect_pon('b'); return; }
      else { bad_window = 0.6f; expect_bad = false; }
    }

  }

  public void expect_drum()
  {
    expect_perfect = true;
    expect_pata('p');
  }

  void expect_pata(char c) 
  { 
    if (Input.GetKeyDown(KeyCode.F) == true) 
    { 
      beat.Invoke();
      if (c == 'p') { audio_source.PlayOneShot(perfect_pata_sound); command += 'F'; }
      if (c == 'g') { audio_source.PlayOneShot(good_pata_sound); command += 'f'; }
      if (c == 'b') { audio_source.PlayOneShot(bad_pata_sound); command += 'x'; }
    } 
  }

  void expect_pon(char c) 
  { 
    if (Input.GetKeyDown(KeyCode.A) == true) 
    { 
      beat.Invoke();
      if (c == 'p') { audio_source.PlayOneShot(perfect_pon_sound); command += 'A'; }
      if (c == 'g') { audio_source.PlayOneShot(good_pon_sound); command += 'a'; }
      if (c == 'b') { audio_source.PlayOneShot(bad_pon_sound); command += 'x';}
    } 
  }
}
