using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class rhythm : MonoBehaviour
{
  [SerializeField] private float bpm;
  [SerializeField] private AudioSource audio_source;
  [SerializeField] private Interval[] intervals;
  public AudioClip horn;
  public AudioClip beat;

  private void Start()
  {
    audio_source.PlayOneShot(horn);
    audio_source.clip = beat;
    audio_source.PlayDelayed(horn.length);
  }

  private void Update()
  {
    foreach (Interval interval in intervals)
    {
      float sampled_time = (audio_source.timeSamples / (audio_source.clip.frequency * interval.get_beat_length(bpm)));
      interval.check_for_new_interval(sampled_time);
    }
  }
}

[System.Serializable]
public class Interval
{
  [SerializeField] private float steps;
  [SerializeField] private UnityEvent trigger;
  [SerializeField] private AudioSource audio_source;
  private int last_interval;
  public AudioClip pata;

  public float get_beat_length(float bpm) { return 60f / (bpm * steps); }

  public void check_for_new_interval (float interval)
  {
    if (Mathf.FloorToInt(interval) != last_interval) 
    { 
      last_interval = Mathf.FloorToInt(interval); 
      trigger.Invoke();
      if (Input.GetKey(KeyCode.Space) == true) 
      { 
        Debug.Log("space"); 
        audio_source.PlayOneShot(pata);
      }
    }
  }
}