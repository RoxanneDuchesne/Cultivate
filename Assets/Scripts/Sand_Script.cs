using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sand_Script : MonoBehaviour
{
    private ParticleSystem sand;
    private float time_counter;

    private bool grow = false;

    // Start is called before the first frame update
    void Start()
    {
        sand = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        float delta_time = Time.time - time_counter;


        if (grow)
        {
            var main = sand.main;
            main.gravityModifier = delta_time * 0.125f;
        }
        else
        {
            var main = sand.main;
            main.gravityModifier = (5 - delta_time) * 0.125f;
        }

        if (delta_time > 5)
        {
            time_counter = Time.time;
            grow = !grow;
        }
    }
}
