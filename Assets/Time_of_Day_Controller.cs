using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Time_of_Day_Controller : MonoBehaviour
{

    private Animator anim;

    int dayHash = Animator.StringToHash("Night_To_Day");
    int nightHash = Animator.StringToHash("Day_To_Night");

    float timestamp;

    public Light light;

    public GameObject breath_tracker_obj;
    private Controller_Breathing_Tracker breath_tracker;

    private bool was_breathing_in = false;
    private bool was_breathing_out = false;

    Color light_0 = new Color(0.8f, 0.7f, 0.7f, 0.1f);
    Color light_1 = new Color(0.9f, 0.4f, 0.4f, 0.1f);

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        breath_tracker = breath_tracker_obj.GetComponent<Controller_Breathing_Tracker>();
    }

    // Update is called once per frame
    void Update()
    {

        if (breath_tracker.breathing_in && !was_breathing_in)
        {
            anim.Play("Day_To_Night");
            //light.color = Color.Lerp(light_0, light_1, 2);

            was_breathing_out = false;
            was_breathing_in = true;
        }
        else if (breath_tracker.breathing_out && !was_breathing_out)
        {
            anim.Play("Night_To_Day");
            //light.color = Color.Lerp(light_1, light_0, 2);

            was_breathing_in = false;
            was_breathing_out = true;
        }

        //anim.Play("Day_To_Night");
    }
}