using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drum : MonoBehaviour {
  public GameObject[] drums;
  public AudioClip[] sounds; 
  public Vector3 speed;
  public AudioSource speaker;

  enum Drums {
    Pata,
    Pon,
    Don,
    Chaka
  }

  void Start() {
  }

  void Update() {
    for (int x = 0; x < drums.Length; x++) {
    }

    if (Input.GetKeyDown(KeyCode.F)) { play_drum((int)Drums.Pata); }
    if (Input.GetKeyDown(KeyCode.A)) { play_drum((int)Drums.Pon); }
    if (Input.GetKeyDown(KeyCode.S)) { play_drum((int)Drums.Don); }
    if (Input.GetKeyDown(KeyCode.D)) { play_drum((int)Drums.Chaka); }

  }

  void play_drum(int sound) {
    speaker.PlayOneShot(sounds[sound]);
  }
}
