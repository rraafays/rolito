using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drum : MonoBehaviour {
  public GameObject[] drums;
  public Vector3 speed;

  enum Drums {
    Pata,
    Pon,
    Don,
    Chaka
  }

  void Start() {
  }

  void Update() {
    for (int x = 0; x < drums.Length; x++) {
      if (x == (int)Drums.Pata) { drums[x].transform.position += speed; }
    }
  }
}
