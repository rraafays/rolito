using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drum : MonoBehaviour {
  public GameObject[] drums;
  public AudioClip[] sounds, voices; 
  public Vector3 speed;
  public AudioSource speaker;
  public string command;

  private enum Name { 
    Pata, 
    Pon, 
    Don, 
    Chaka 
  }

  private enum Command { 
    Attack, 
    Defend, 
    March 
  }

  private enum Quality {
    Perfect,
    Good,
    Bad
  }

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
    
    if (get_quality(drums[(int)pata.name]) == Quality.Perfect) { command += 'F'; }
    if (get_quality(drums[(int)pon.name]) == Quality.Perfect) { command += 'A'; }
    if (get_quality(drums[(int)don.name]) == Quality.Perfect) { command += 'S'; }
    if (get_quality(drums[(int)chaka.name]) == Quality.Perfect) { command += 'D'; }

    execute(command);
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

  Quality get_quality(GameObject game_object) {
    if (game_object.GetComponent<button>().perfect) {
      game_object.GetComponent<button>().perfect = false;
      return Quality.Perfect; 
    }
    if (game_object.GetComponent<button>().good) {
      game_object.GetComponent<button>().good = false;
      return Quality.Good; 
    }
    if (game_object.GetComponent<button>().bad) {
      game_object.GetComponent<button>().bad = false;
      return Quality.Bad; 
    }
    else { return Quality.Bad; }
  }

  void execute(string command) {
    if (command.Length > 0 && command.Length % 4 == 0) {
      speaker.PlayOneShot(voices[(int)Command.March]);
      this.command = "";
    }
  }
}
