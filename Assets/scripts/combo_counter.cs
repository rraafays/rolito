using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class combo_counter : MonoBehaviour
{
  public GameObject badge;
  public GameObject icon;
  public TMP_Text combo;

  void Start() {
  }

  void Update() {
    badge.transform.Rotate(0, 0, -.1f);
    if (int.Parse(combo.text) == 0) {
    }
  }
}
