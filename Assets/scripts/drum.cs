using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drum : MonoBehaviour {
  public GameObject[] drums;
  public AudioClip[] sounds; 
  public Vector3 speed;
  public AudioSource speaker;
  public string command;

  enum Drums {
    Pata,
    Pon,
    Don,
    Chaka
  }

  void Start() {
  }

  void Update() {
    if (Input.GetKeyDown(KeyCode.F)) { play_drum(Drums.Pata); }
    if (Input.GetKeyDown(KeyCode.A)) { play_drum(Drums.Pon); }
    if (Input.GetKeyDown(KeyCode.S)) { play_drum(Drums.Don); }
    if (Input.GetKeyDown(KeyCode.D)) { play_drum(Drums.Chaka); }
    
    if (drums[0].GetComponent<button>().perfect) {
      play_drum(Drums.Don);
    }
  }

  void play_drum(Drums sound) {
    speaker.PlayOneShot(sounds[(int)sound]);
  }
}
