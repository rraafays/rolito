using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{
  public bool can_be_pressed;
  public bool test;
  
  void Start() {
  }

  void Update() {
    if (pressed_on_time(KeyCode.F)) {
      test = true;
    }
  }

  private void OnTriggerEnter2D(Collider2D other) {
    if (other.tag == "beat") {
      can_be_pressed = true;
    }
  }

  private void OnTriggerExit2D(Collider2D other) {
    if (other.tag == "beat") {
      can_be_pressed = false;
    }
  }

  private bool pressed_on_time(KeyCode key) {
    if (Input.GetKeyDown(key) && can_be_pressed) { return true; }
    else { return false; }
  }
}