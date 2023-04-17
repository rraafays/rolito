using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beat : MonoBehaviour
{
  private float tempo = 120;

  void Start() {
    tempo = tempo / 60;
  }

  void Update() {
    transform.position -= new Vector3(0, tempo * Time.deltaTime, 0);
  }
}