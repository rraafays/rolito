using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class drum : MonoBehaviour
{
    [SerializeField] private float bpm;
    [SerializeField] private AudioSource audio_source;
    [SerializeField] private Interval[] intervals;

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
    private int last_interval;

    public float get_beat_length(float bpm) { return 60f / (bpm * steps); }

    public void check_for_new_interval (float interval)
    {
        if (Mathf.FloorToInt(interval) != last_interval) 
        { 
            last_interval = Mathf.FloorToInt(interval); 
            trigger.Invoke();
        }
    }
}
