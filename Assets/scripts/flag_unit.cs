using UnityEngine;

public class flag_unit : MonoBehaviour
{
  public GameObject drum;
  public Animator anim;

  void Start() {
  }

  void Update() {
    if (drum.GetComponent<drum>().command == "fffa") {
      anim.CrossFade("wave_flag", 0, 0, 0);
    }
  }
}
