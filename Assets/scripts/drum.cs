using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class drum : MonoBehaviour
{
  [SerializeField] private AudioSource audio_source; // audio source to play each drum hit
  // various drum events
  [SerializeField] private UnityEvent beat;
  [SerializeField] private UnityEvent perfect_forward;
  [SerializeField] private UnityEvent good_forward;
  [SerializeField] private UnityEvent bad_forward;
  [SerializeField] private UnityEvent perfect_attack;
  [SerializeField] private UnityEvent good_attack;
  [SerializeField] private UnityEvent bad_attack;

  // booleans for control flow
  private bool expect_perfect = false;
  private bool expect_good = false;
  private bool expect_bad = false;

  // leniency windows
  private float perfect_window = 0.1f;
  private float good_window = 0.3f;
  private float bad_window = 0.6f;

  // booleans for playing the correct drum sound
  private bool perfect_pata;
  private bool good_pata;
  private bool bad_pata;
  // audio clips for each drum sound
  public AudioClip perfect_pata_sound;
  public AudioClip good_pata_sound;
  public AudioClip bad_pata_sound;
  public AudioClip perfect_pon_sound;
  public AudioClip good_pon_sound;
  public AudioClip bad_pon_sound;

  public GameObject pata; // pata symbol
  public GameObject pon; // pon symbol
  public Vector3 right_area; // right half of screen
  public Vector3 left_area; // left half of screen
  public Vector3 size; // size of the area

  private string command = ""; // empty command

  private void Start() { }

  private void Update()
  {
    if (command.Length > 4) { command = ""; } // if the command is greater than 4, clear it
    if (command.Length == 4) // if the command is 4, enter command detection
    { 
      Debug.Log(command); // log the command
      if (command.ToLower()[0] == 'f' && command.ToLower()[3] == 'a' ) // if the command starts with f and ends in a
      { 
        if (command.Contains('f') || command.Contains('a')) { good_forward.Invoke(); } // if there are some good inputs then do a good forward
        if (command.Contains('x')) { bad_forward.Invoke(); } // if there are no inputs then do a bad forward
        if (command == "FFFA" ) { perfect_forward.Invoke(); } // if the input is perfect do a perfect forward
        // TODO: repeat for pon
      }

      command = "";  // clear the command
    }

    if (expect_perfect) // if perfect input is expected
    {
      perfect_window -= Time.smoothDeltaTime; // decrease the time window
      if (perfect_window >= 0) { expect_pata('p'); expect_pon('p'); return; } // perfect input during the window
      else { perfect_window = 0.1f; expect_perfect = false; expect_good = true; } // lock perfect window and expect good input miss
    }
    if (expect_good) // if perfect was missed
    {
      good_window -= Time.smoothDeltaTime; // decrease the time window
      if (good_window >= 0) { expect_pata('g'); expect_pon('g'); return; } // good input during the window
      else { good_window = 0.3f; expect_good = false; expect_bad = true; } // lock the good window and expect bad input on miss
    }
    if (expect_bad) // if good was missed
    {
      bad_window -= Time.smoothDeltaTime; // decrease the time window
      if (bad_window >= 0) { expect_pata('b'); expect_pon('b'); return; } // bad input during the window
      else { bad_window = 0.6f; expect_bad = false; } // lock the bad window
    }
  }

  public void reset_drum() { command = ""; } // external command reset

  public void expect_drum() // expect a drum beat
  {
    expect_perfect = true; // open perfect window
    // if the input is just frame immediately make it perfect
    expect_pata('p'); 
    expect_pon('p');
  }

  void expect_pata(char c) 
  { 
    if (Input.GetKeyDown(KeyCode.F) == true) // if 'f' is pressed
    { 
      beat.Invoke(); // beat the drum
      spawn_drum_beat(right_area, pata); // spawn a drum symbol to the right
      if (c == 'p') { audio_source.PlayOneShot(perfect_pata_sound); command += 'F'; } // if perfect add perfect input to command
      if (c == 'g') { audio_source.PlayOneShot(good_pata_sound); command += 'f'; } // if good add good inout to command
      if (c == 'b') { audio_source.PlayOneShot(bad_pata_sound); command += 'x'; } // if badd add bad input to command
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

  private void spawn_drum_beat(Vector3 area, GameObject drum_beat) // spawn drum symbol around the center of an area
  {
    Vector3 position = area + new Vector3(Random.Range(-size.x / 2, size.x /2), Random.Range(-size.y / 2, size.y / 2), 0); // generate a position around provided area
    Instantiate(drum_beat, position, Quaternion.identity); // instantiate the drum symbol at that random area
  }
}
