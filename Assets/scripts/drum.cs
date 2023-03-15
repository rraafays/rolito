using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class drum : MonoBehaviour
{
  [SerializeField] private AudioSource audio_source;
  public AudioClip pata;

  private void Start()
  {
  }

  private void Update()
  {
  }

  public void play_pata()
  {
    audio_source.PlayOneShot(pata);
  }
}
