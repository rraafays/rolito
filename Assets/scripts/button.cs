using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{
  public KeyCode bind;
  private bool can_be_pressed;
  public bool perfect;
  public bool good;
  public bool bad;
  
  enum Quality {
    Perfect,
    Good,
    Bad
  }

  void Update() {
    if (pressed_on_time(bind) == Quality.Perfect) { perfect = true; }
    if (pressed_on_time(bind) == Quality.Good) { good = true; }
    if (pressed_on_time(bind) == Quality.Bad) { bad = true; }
  }

  private Quality pressed_on_time(KeyCode key) {
    if (Input.GetKeyDown(key) && can_be_pressed) { return Quality.Perfect; }
    if (Input.GetKeyDown(key) && !can_be_pressed) { return Quality.Good; }
    else { return Quality.Bad; }
  }

  private void OnTriggerEnter2D(Collider2D other) {
    if (other.tag == "beat") { can_be_pressed = true; }
  }

  private void OnTriggerExit2D(Collider2D other) {
    if (other.tag == "beat") { can_be_pressed = false; }
  }
}
