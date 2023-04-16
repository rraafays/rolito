using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beat : MonoBehaviour
{
  public float tempo;
  public bool started;
  public bool can_be_pressed;

  void Start() {
    tempo = tempo / 60;
  }

  void Update() {
    if(Input.GetKeyDown(KeyCode.Space)) { started = true; }
    if (started) {
      transform.position -= new Vector3(0, tempo * Time.deltaTime, 0);
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
}
