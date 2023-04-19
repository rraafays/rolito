using UnityEngine;

public class rhythm : MonoBehaviour
{
  public GameObject beat; 
  public AudioSource speaker;
  public AudioClip[] loops;
  public GameObject drum;
  public float spawn_rate;
  private float timer;

  enum Loop {
    Begin01,
    Begin02,
    Combo01,
    Combo02,
    Combo03,
    Fever01,
    Fever02
  }

  void Start() {
    speaker.PlayOneShot(loops[(int)Loop.Begin01]);
    speaker.clip = loops[(int)Loop.Begin02];
    speaker.PlayDelayed(loops[(int)Loop.Begin01].length);
    send_beat();
  }

  void Update() {
    if (timer < spawn_rate) {
      timer += Time.deltaTime;
    }
    else { 
      send_beat();
      timer = 0;
    }

    if (drum.GetComponent<drum>().combo == 3) {
      speaker.clip = loops[(int)Loop.Combo01];
      if (!speaker.isPlaying) { speaker.PlayDelayed(.5f); }
    }
    if (drum.GetComponent<drum>().combo == 6) {
      speaker.clip = loops[(int)Loop.Combo02];
      if (!speaker.isPlaying) { speaker.PlayDelayed(.5f); }
    }
    if (drum.GetComponent<drum>().combo == 9) {
      speaker.clip = loops[(int)Loop.Combo03];
      if (!speaker.isPlaying) { speaker.PlayDelayed(.5f); }
    }
    if (drum.GetComponent<drum>().combo == 12) {
      speaker.clip = loops[(int)Loop.Fever01];
      if (!speaker.isPlaying) { speaker.PlayDelayed(.5f); }
    }
    if (drum.GetComponent<drum>().combo == 15) {
      speaker.clip = loops[(int)Loop.Fever02];
      if (!speaker.isPlaying) { speaker.PlayDelayed(.5f); }
    }
  }

  void send_beat() { 
    if (beat != null) { Instantiate(beat, transform.position, transform.rotation); }
  }
}
