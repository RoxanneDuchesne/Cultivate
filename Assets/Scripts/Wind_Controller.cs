using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind_Controller : MonoBehaviour
{

    public GameObject breath_tracker_obj;
    public bool out_wind = true;
    private ParticleSystem wind;

    private Controller_Breathing_Tracker breath_tracker;
    private bool last_breathe_in = false;

    // Start is called before the first frame update
    void Start()
    {
        breath_tracker = breath_tracker_obj.GetComponent<Controller_Breathing_Tracker>();
        wind = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {

        if (breath_tracker.breathing_in && !last_breathe_in)
        {
            if (out_wind)
            {
                var me = wind.emission;
                me.enabled = false;
            }
            else
            {
                var me = wind.emission;
                me.enabled = true;
                wind.Simulate(0.0f, true, true);
                wind.Play();
            }


            last_breathe_in = true;
        }
        else if (breath_tracker.breathing_out && last_breathe_in)
        { 
            if (out_wind)
            {
                var me = wind.emission;
                me.enabled = true;
                wind.Simulate(0.0f, true, true);
                wind.Play();
            }
            else
            {
                var me = wind.emission;
                me.enabled = false;
            }

            last_breathe_in = false;
        }
        /*
        if (!breath_tracker.calibrated)// || (!breath_tracker.breathing_out && !breath_tracker.breathing_in))
        {
            var me = wind.emission;
            me.enabled = false;
        }
        */
    }
}
