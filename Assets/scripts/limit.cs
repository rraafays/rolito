using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class limit : MonoBehaviour
{
  public string message;

  void OnTriggerStay2D() 
  { 
    if (Input.GetKey(KeyCode.Space) == true) { Debug.Log(message); }
  }
}
