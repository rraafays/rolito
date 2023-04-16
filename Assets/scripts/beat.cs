using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beat : MonoBehaviour
{
  public float tempo;
  public bool started;
  public bool can_be_pressed;
  public bool test;

  void Start() {
    tempo = tempo / 60;
  }

  void Update() {
    if (Input.GetKeyDown(KeyCode.Space)) { started = true; }
    if (started) {
      transform.position -= new Vector3(0, tempo * Time.deltaTime, 0);
    }

    if (pressed_on_time(KeyCode.F)) {
      test = true;
    }
  }

  private void OnTriggerEnter2D(Collider2D other) {
    if (other.tag == "activator") {
      can_be_pressed = true;
    }
  }

  private void OnTriggerExit2D(Collider2D other) {
    if (other.tag == "activator") {
      can_be_pressed = false;
    }
  }

  private bool pressed_on_time(KeyCode key) {
    if (Input.GetKeyDown(key) && can_be_pressed) { return true; }
    else { return false; }
  }
}
