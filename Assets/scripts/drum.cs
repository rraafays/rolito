using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class drum : MonoBehaviour
{
  [SerializeField] private AudioSource audio_source;
  [SerializeField] private UnityEvent beat;
  [SerializeField] private UnityEvent perfect_forward;
  [SerializeField] private UnityEvent good_forward;
  [SerializeField] private UnityEvent bad_forward;
  [SerializeField] private UnityEvent perfect_attack;
  [SerializeField] private UnityEvent good_attack;
  [SerializeField] private UnityEvent bad_attack;

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

  public GameObject pata;
  public GameObject pon;
  public Vector3 right_area;
  public Vector3 left_area;
  public Vector3 size;

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
      if (command.ToLower()[0] == 'f' && command.ToLower()[3] == 'a' ) 
      { 
        if (command.Contains('f') || command.Contains('a')) { good_forward.Invoke(); }
        if (command.Contains('x')) { bad_forward.Invoke(); }
        if (command == "FFFA" ) { perfect_forward.Invoke(); }
      }

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

  public void reset_drum() { command = ""; }

  public void expect_drum()
  {
    expect_perfect = true;
    expect_pata('p');
    expect_pata('a');
  }

  void expect_pata(char c) 
  { 
    if (Input.GetKeyDown(KeyCode.F) == true) 
    { 
      beat.Invoke();
      spawn_drum_beat(right_area, pata);
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
      spawn_drum_beat(left_area, pon);
      if (c == 'p') { audio_source.PlayOneShot(perfect_pon_sound); command += 'A'; }
      if (c == 'g') { audio_source.PlayOneShot(good_pon_sound); command += 'a'; }
      if (c == 'b') { audio_source.PlayOneShot(bad_pon_sound); command += 'x';}
    } 
  }

  private void spawn_drum_beat(Vector3 area, GameObject drum_beat)
  {
    Vector3 position = area + new Vector3(Random.Range(-size.x / 2, size.x /2), Random.Range(-size.y / 2, size.y / 2), 0);
    Instantiate(drum_beat, position, Quaternion.identity);
  }
}
