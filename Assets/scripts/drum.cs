using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drum : MonoBehaviour {
  public GameObject[] drums;
  public AudioClip[] sounds; 
  public Vector3 speed;
  public AudioSource speaker;
  public string command;

  private enum Name { Pata, Pon, Don, Chaka }
  private struct Drum {
    public Name name;
    public KeyCode bind;

    public Drum(Name name, KeyCode bind) {
      this.name = name;
      this.bind = bind;
    }
  }

  Drum pata = new Drum(Name.Pata, KeyCode.F);
  Drum pon = new Drum(Name.Pon, KeyCode.A);
  Drum don = new Drum(Name.Don, KeyCode.S);
  Drum chaka = new Drum(Name.Chaka, KeyCode.D);

  void Start() {}

  void Update() {
    if (is_hit(pata)) { chant(pata); }
    if (is_hit(pon)) { chant(pon); }
    if (is_hit(don)) { chant(don); }
    if (is_hit(chaka)) { chant(chaka); }
    
    if (is_perfect(drums[(int)pata.name])) {
      chant(don);
      drums[(int)pata.name].GetComponent<button>().perfect = false;
    }
  }

  void chant(Drum drum) {
    speaker.PlayOneShot(sounds[(int)drum.name]);
  }

  void reset_perfect(GameObject drum) {
    drum.GetComponent<button>().perfect = false;
  }

  bool is_hit(Drum drum) {
    if (Input.GetKeyDown(drum.bind)) { return true; }
    else { return false; }
  }

  bool is_perfect(GameObject game_object) {
    if (game_object.GetComponent<button>().perfect) {return true;}
    else { return false; }
  }
}