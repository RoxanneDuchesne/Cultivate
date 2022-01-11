using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sand_Script : MonoBehaviour
{
    private ParticleSystem sand;
    private float time_counter;

    // Start is called before the first frame update
    void Start()
    {
        sand = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        float delta_time = Time.time - time_counter;

        if (delta_time > 9)
        {
            var main = sand.main;
            main.gravityModifier = 0.125f;

            time_counter = Time.time;
        }
        else if (delta_time > 8)
        {
            var main = sand.main;
            main.gravityModifier = 0.25f;
        }
        else if (delta_time > 7)
        {
            var main = sand.main;
            main.gravityModifier = 0.375f;
        }
        else if (delta_time > 6)
        {
            var main = sand.main;
            main.gravityModifier = 0.5f;
        }
        else if (delta_time > 5)
        {
            var main = sand.main;
            main.gravityModifier = 0.525f;
        }
        else if (delta_time > 4)
        {
            var main = sand.main;
            main.gravityModifier = 0.5f;
        }
        else if (delta_time > 3)
        {
            var main = sand.main;
            main.gravityModifier = 0.375f;
        }
        else if (delta_time > 2)
        {
            var main = sand.main;
            main.gravityModifier = 0.25f;
        }
        else if (delta_time > 1)
        {
            var main = sand.main;
            main.gravityModifier = 0.125f;
        }
        else if (delta_time > 0)
        {
            var main = sand.main;
            main.gravityModifier = 0.0f;
        }
    }
}
