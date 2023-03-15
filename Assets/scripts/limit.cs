using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class limit : MonoBehaviour
{
  void Start()
  {
  }

  void Update() 
  { 
  }

  void OnTriggerStay2D() 
  { 
    if (Input.GetKey(KeyCode.Space) == true) { Debug.Log("SPACEMAN"); }
  }
}
