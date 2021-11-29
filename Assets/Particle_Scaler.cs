using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle_Scaler : MonoBehaviour
{
    private ParticleSystem ps;
    public Vector3 scale_change = new Vector3(0.0001f, 0.0001f, 0.0001f);
    public ParticleSystemScalingMode scaleMode;


    private bool breathing_in = false;
    private float timestamp = 0;

    void Start()
    {
        timestamp = Time.time;
        ps = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        //ps.transform.localScale += new Vector3(sliderValue, sliderValue, sliderValue);

        if (breathing_in && Time.time - timestamp < 5)
        {
            ps.transform.localScale += scale_change;
        }
        else if (!breathing_in && Time.time - timestamp < 5)
        {
            ps.transform.localScale -= scale_change;
        }
        else
        {
            breathing_in = !breathing_in;
            timestamp = Time.time;
        }

        if (ps.transform.parent != null)
            ps.transform.parent.localScale = new Vector3(1, 1, 1);
        var main = ps.main;
        main.scalingMode = scaleMode;
    }

}
