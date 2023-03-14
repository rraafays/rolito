using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject prefab;
    public float spawn_rate = 2;
    private float timer = 0;
    public float y_offset = 10;

    // Start is called before the first frame update
    void Start()
    {
        spawn();
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
            spawn();
            timer = 0;
        }     
    }

    void spawn() 
    { 
        float y_minimum = transform.position.y - y_offset;
        float y_maximum = transform.position.y + y_offset;

        Instantiate(prefab, new Vector3(transform.position.x, Random.Range(y_minimum, y_maximum), 0), transform.rotation); 
    }
}
