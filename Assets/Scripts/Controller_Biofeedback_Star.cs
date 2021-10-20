using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Biofeedback_Star : MonoBehaviour
{
    public Fraktalia.DreamStarGen.DreamStarGenerator star_generator;

    public GameObject breath_tracker_obj;
    private Controller_Breathing_Tracker breath_tracker;

    public bool with_breath = true;

    public float pulse_speed = 2.0f;

    private bool breathing_in = false;
    
    // Start is called before the first frame update
    void Start()
    {
        star_generator = GetComponent<Fraktalia.DreamStarGen.DreamStarGenerator>();
        breath_tracker = breath_tracker_obj.GetComponent<Controller_Breathing_Tracker>();
    }

    // Update is called once per frame
    void Update()
    {
        if (with_breath)
        {

            if (breath_tracker.breathing_in)
            {
                breathing_in = true;
            }
            else if (breath_tracker.breathing_out)
            {
                breathing_in = false;
            }

            if (star_generator.Radius < 20 && breathing_in)
            {
                star_generator.Radius += pulse_speed * Time.deltaTime;
            }
            else if (star_generator.Radius > 0 && !breathing_in)
            {
                star_generator.Radius -= pulse_speed * Time.deltaTime;
            }
        }
        else
        {
            if (breath_tracker.correct_consecutive_breaths > 0)
            {
                star_generator.Radius += Time.deltaTime * 0.4f;
            }
            else if (star_generator.Radius > 0)
            {
                star_generator.Radius -= Time.deltaTime * 0.4f;
            }
        }
        
    }
}
