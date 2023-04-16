using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beat : MonoBehaviour
{
  public float tempo;
  public bool started;

  void Start() {
    tempo = tempo / 60;
  }

  void Update() {
    if (Input.GetKeyDown(KeyCode.Space)) { started = true; }
    if (started) {
      transform.position -= new Vector3(0, tempo * Time.deltaTime, 0);
    }
  }
}