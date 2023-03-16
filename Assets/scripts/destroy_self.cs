using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy_self : MonoBehaviour
{
  public GameObject self;

  void Start()
  {
    Destroy(self, 0.5f);
  }
}
