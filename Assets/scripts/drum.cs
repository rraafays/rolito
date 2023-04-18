using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class drum : MonoBehaviour {
  public GameObject[] drums;
  public TMP_Text combo_counter;
  public AudioClip[] sounds, voices; 
  public Vector3 speed;
  public AudioSource speaker;
  public string command;
  private int combo;

  private enum Name { 
    Pata, 
    Pon, 
    Don, 
    Chaka 
  }

  private enum Action { 
    Attack, 
    Defend, 
    March,
    None
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

    switch (get_quality(drums[(int)pata.name])) {
      case Quality.Perfect: command += 'F'; break;
      case Quality.Good: command += 'f'; break;
    }
    switch (get_quality(drums[(int)pon.name])) {
      case Quality.Perfect: command += 'A'; break;
      case Quality.Good: command += 'a'; break;
    }
    switch (get_quality(drums[(int)don.name])) {
      case Quality.Perfect: command += 'S'; break;
      case Quality.Good: command += 's'; break;
    }
    switch (get_quality(drums[(int)chaka.name])) {
      case Quality.Perfect: command += 'D'; break;
      case Quality.Good: command += 'd'; break;
    }

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
      game_object.GetComponent<button>().can_be_pressed = false;
      return Quality.Perfect; 
    }
    if (game_object.GetComponent<button>().good) {
      game_object.GetComponent<button>().good = false;
      game_object.GetComponent<button>().can_be_pressed = false;
      return Quality.Good; 
    }
    if (game_object.GetComponent<button>().bad) {
      game_object.GetComponent<button>().bad = false;
      game_object.GetComponent<button>().can_be_pressed = false;
      return Quality.Bad; 
    }
    else { return Quality.Bad; }
  }

  void execute(string command) {
    if (command.Length > 0 && command.Length % 4 == 0) {
      (Quality, Action) action = get_action(command);
      if (action.Item2 == Action.March) { 
        march(action.Item1); 
      }
      if (action.Item2 == Action.Attack) { 
        attack(action.Item1); 
      }
      if (action.Item2 == Action.Defend) { 
        defend(action.Item1); 
      }
      this.command = "";
      combo += 1;
      combo_counter.text = combo.ToString();
      Debug.Log(combo);
    }
  }

  (Quality, Action) get_action(string command) {
    if (command == "fffa") { 
      if (command.Contains('F') && command.Contains('A')) { 
        return (Quality.Perfect, Action.March);
      }
      else { return (Quality.Good, Action.March); }
    }
    if (command == "aafa") { 
      if (command.Contains('F') && command.Contains('A')) { 
        return (Quality.Perfect, Action.Attack);
      }
      else { return (Quality.Good, Action.Attack); }
    }
    if (command == "ddfa") { 
      if (command.Contains('F') && command.Contains('A')) { 
        return (Quality.Perfect, Action.Defend);
      }
      else { return (Quality.Good, Action.Defend); }
    }
    else { return (Quality.Perfect, Action.None); }
  } 

  void march(Quality quality) {
    speaker.clip = voices[(int)Action.March];
    speaker.PlayDelayed(0.5f);
  }
  void attack(Quality quality) {
    speaker.clip = voices[(int)Action.Attack];
    speaker.PlayDelayed(0.5f);
  }
  void defend(Quality quality) {
    speaker.clip = voices[(int)Action.Defend];
    speaker.PlayDelayed(0.5f);
  }
}
