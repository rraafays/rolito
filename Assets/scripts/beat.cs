using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beat : MonoBehaviour
{
  private float tempo = 120;
  private float despawn_point = -1;

  void Start() {
    tempo = tempo / 60;
  }

  void Update() {
    transform.position -= new Vector3(0, tempo * Time.deltaTime, 0);
    if (transform.position.y < despawn_point) {
      if (gameObject != null) {
        Destroy(gameObject);
      }
    }
  }
}