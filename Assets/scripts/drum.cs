using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drum : MonoBehaviour {
  public GameObject[] drums;
  public AudioClip[] sounds; 
  public Vector3 speed;
  public AudioSource speaker;
  public string command;

  private enum Sound {
    Pata,
    Pon,
    Don,
    Chaka
  }

  private struct Drum {
    public Sound sound;
    public KeyCode bind;

    public Drum(Sound sound, KeyCode bind) {
      this.sound = sound;
      this.bind = bind;
    }
  }

  Drum pata = new Drum(Sound.Pata, KeyCode.F);
  Drum pon = new Drum(Sound.Pon, KeyCode.A);
  Drum don = new Drum(Sound.Don, KeyCode.S);
  Drum chaka = new Drum(Sound.Chaka, KeyCode.D);

  void Start() {
  }

  void Update() {
    if (is_hit(pata)) { chant(pata); }
    if (is_hit(pon)) { chant(pon); }
    if (is_hit(don)) { chant(don); }
    if (is_hit(chaka)) { chant(chaka); }
    
    if (drums[0].GetComponent<button>().perfect) {
      chant(don);
      drums[0].GetComponent<button>().perfect = false;
    }
  }

  void chant(Drum drum) {
    speaker.PlayOneShot(sounds[(int)drum.sound]);
  }

  void reset_perfect(GameObject drum) {
    drum.GetComponent<button>().perfect = false;
  }

  bool is_hit(Drum drum) {
    if (Input.GetKeyDown(drum.bind)) { return true; }
    else { return false; }
  }
}