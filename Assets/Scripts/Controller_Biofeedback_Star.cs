using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Biofeedback_Star : MonoBehaviour
{
    public Fraktalia.DreamStarGen.DreamStarGenerator star_generator;

    public GameObject breath_tracker_obj;
    private Controller_Breathing_Tracker breath_tracker;
    
    // Start is called before the first frame update
    void Start()
    {
        star_generator = GetComponent<Fraktalia.DreamStarGen.DreamStarGenerator>();
        breath_tracker = breath_tracker_obj.GetComponent<Controller_Breathing_Tracker>();
    }

    // Update is called once per frame
    void Update()
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
