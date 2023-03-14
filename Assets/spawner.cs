using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject prefab;
    public float spawn_rate = 2;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawn_rate) 
        {
            timer += Time.deltaTime;
        }
        else
        {
            Instantiate(prefab, transform.position, transform.rotation);
            timer = 0;
        }     
    }
}
