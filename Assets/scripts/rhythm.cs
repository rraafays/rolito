using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class rhythm : MonoBehaviour
{
  [SerializeField] private float bpm; // beats per minute of track
  [SerializeField] private AudioSource audio_source;
  [SerializeField] private Interval[] intervals;
  public AudioClip horn; // start horn
  public AudioClip beat; // main beat loop

  private void Start()
  {
    audio_source.PlayOneShot(horn); // play the start horn
    audio_source.clip = beat; // switch to the beat
    audio_source.PlayDelayed(horn.length); // loop the beat
  }

  private void Update()
  {
    foreach (Interval interval in intervals) // for each interval created
    {
      float sampled_time = (audio_source.timeSamples / (audio_source.clip.frequency * interval.get_beat_length(bpm))); // check for a new interval at the sampled time
      interval.check_for_new_interval(sampled_time);
    }
  }
}

[System.Serializable]
public class Interval
{
  [SerializeField] private float steps; // number of steps per beat
  [SerializeField] private UnityEvent trigger; // event trigger for each beat
  private int last_interval;

  public float get_beat_length(float bpm) { return 60f / (bpm * steps); } // get the length of the beat

  public void check_for_new_interval (float interval) // check for interval
  {
    if (Mathf.FloorToInt(interval) != last_interval)  // floor the interval and check if they are equivalent
    { 
      last_interval = Mathf.FloorToInt(interval); // if they are then set the last interval to current
      trigger.Invoke(); // trigger event
    }
  }
}
