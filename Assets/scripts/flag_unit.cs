using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flag_unit : MonoBehaviour
{
    [SerializeField] bool use_test_beat;
    [SerializeField] float pulse_size = 1.15f;
    [SerializeField] float return_speed = 5f;
    private Vector3 start_size;

    void Start()
    {
        start_size = transform.localScale;
        if (use_test_beat) { StartCoroutine(test_beat()); }
    }

    void Update() { transform.localScale = Vector3.Lerp(transform.localScale, start_size, Time.deltaTime * return_speed); }

    public void beat() { transform.localScale = start_size * pulse_size; }

    IEnumerator test_beat()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            beat();
        }
    }
}
