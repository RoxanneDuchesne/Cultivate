using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle_Controller_Dune : MonoBehaviour
{

    public ParticleSystem vortex_0;
    public ParticleSystem vortex_1;
    public ParticleSystem vortex_2;
    public ParticleSystem vortex_3;
    public ParticleSystem vortex_4;
    public ParticleSystem vortex_5;
    public ParticleSystem vortex_6;
    public ParticleSystem vortex_7;
    public ParticleSystem vortex_8;
    public ParticleSystem vortex_9;
    public ParticleSystem vortex_10;
    public ParticleSystem vortex_11;
    public ParticleSystem vortex_12;
    public ParticleSystem vortex_13;
    public ParticleSystem vortex_14;
    public ParticleSystem vortex_15;
    public ParticleSystem vortex_16;
    public ParticleSystem vortex_17;
    public ParticleSystem vortex_18;
    public ParticleSystem vortex_19;

    private ParticleSystem[] vortex;

    public Vector3 scale_change = new Vector3(0.00f, 1f, 0f);

    private bool breathing_in = false;
    private float timestamp = 0;

    // Start is called before the first frame update
    void Start()
    {
        vortex[0] = vortex_0;
        vortex[1] = vortex_1;
        vortex[2] = vortex_2;
        vortex[3] = vortex_3;
        vortex[4] = vortex_4;
        vortex[5] = vortex_5;
        vortex[6] = vortex_6;
        vortex[7] = vortex_7;
        vortex[8] = vortex_8;
        vortex[9] = vortex_9;
        vortex[10] = vortex_10;
        vortex[11] = vortex_11;
        vortex[12] = vortex_12;
        vortex[13] = vortex_13;
        vortex[14] = vortex_14;
        vortex[15] = vortex_15;
        vortex[16] = vortex_16;
        vortex[17] = vortex_17;
        vortex[18] = vortex_18;
        vortex[19] = vortex_19;

        timestamp = Time.time;

        vortex_0.transform.localScale = new Vector3(5, 5, 5);
    }

    // Update is called once per frame
    void Update()
    {

        if (breathing_in && Time.time - timestamp < 5)
        {
            foreach (ParticleSystem v in vortex)
            {
                v.transform.position += scale_change;
            }
        }
        else if (!breathing_in && Time.time - timestamp < 5)
        {
            foreach (ParticleSystem v in vortex)
            {
                v.transform.position -= scale_change;
            }
        }
        else
        {
            breathing_in = !breathing_in;
            timestamp = Time.time;
        }
    }
}
