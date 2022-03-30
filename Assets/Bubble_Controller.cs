using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble_Controller : MonoBehaviour
{
    public GameObject breath_tracker_obj;
    private Controller_Breathing_Tracker breath_tracker;

    public GameObject bubbles_obj;
    private ParticleSystem bubbles;
    private ParticleSystem.EmissionModule bubbles_emission;

    public GameObject bubbles_fast_obj;
    private ParticleSystem bubbles_fast;
    private ParticleSystem.EmissionModule bubbles_fast_emission;

    public GameObject bubbles_slow_obj;
    private ParticleSystem bubbles_slow;
    private ParticleSystem.EmissionModule bubbles_slow_emission;

    // Start is called before the first frame update
    void Start()
    {
        breath_tracker = breath_tracker_obj.GetComponent<Controller_Breathing_Tracker>();

        bubbles = bubbles_obj.GetComponent<ParticleSystem>();
        bubbles_fast = bubbles_fast_obj.GetComponent<ParticleSystem>();
        bubbles_slow = bubbles_slow_obj.GetComponent<ParticleSystem>();


        bubbles_emission = bubbles.emission;
        bubbles_emission.enabled = false;

        bubbles_fast_emission = bubbles_fast.emission;
        bubbles_fast_emission.enabled = false;

        bubbles_slow_emission = bubbles_slow.emission;
        bubbles_slow_emission.enabled = false;
    }

    // Update is called once per frame
    void Update()
    { 
        if (breath_tracker.breathing_out)
        {
            bubbles_emission.enabled = false;
            bubbles_fast_emission.enabled = false;
            bubbles_slow_emission.enabled = false;

            if (breath_tracker.last_breath_at_frequency)
            {
                bubbles_emission.enabled = true;
            }
            else if(breath_tracker.last_breath_too_fast)
            {
                bubbles_fast_emission.enabled = true;
            }
            else if(breath_tracker.last_breath_too_slow)
            {
                bubbles_slow_emission.enabled = true;
            }
        }
        else if(breath_tracker.breathing_in)
        {
            bubbles_emission.enabled = false;
            bubbles_fast_emission.enabled = false;
            bubbles_slow_emission.enabled = false;
        }
    }
}
