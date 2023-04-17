using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rhythm : MonoBehaviour
{
  public GameObject beat; 
  public float spawn_rate;
  private float timer;
  public AudioSource speaker;
  public AudioClip[] loops;

  enum Loop {
    Stage1,
    Stage2,
    Stage3
  }

  void Start() {
    speaker.clip = loops[(int)Loop.Stage1];
    speaker.Play();
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
  }

  void send_beat() { Instantiate(beat, transform.position, transform.rotation); }
}
