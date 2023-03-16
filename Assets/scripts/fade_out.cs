using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fade_out : MonoBehaviour
{
  public GameObject obj;
  private bool can_fade;
  private Color alpha_color;
  private float time_to_fade = 1.0f;

  public void Start()
  {
    can_fade = false;
    alpha_color = obj.GetComponent<Renderer>().material.color;
    alpha_color.a = 0;
  }

  public void Update()
  {
    if (can_fade)
    {
      obj.GetComponent<Renderer>().material.color = Color.Lerp(obj.GetComponent<Renderer>().material.color, alpha_color, time_to_fade * Time.deltaTime);
    }
  }
}
