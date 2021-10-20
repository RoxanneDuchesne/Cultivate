using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debug_Text : MonoBehaviour
{
    public GameObject menu;
    public GameObject breath_tracker_obj;

    private UnityEngine.UI.Text debug_text;
    private Controller_Breathing_Tracker breath_tracker;

    // Start is called before the first frame update
    void Start()
    {
        debug_text = menu.GetComponent<UnityEngine.UI.Text>();
        breath_tracker = breath_tracker_obj.GetComponent<Controller_Breathing_Tracker>();
    }

    // Update is called once per frame
    void Update()
    {
        string debug_log = "";

        debug_log += "Debug_Menu: \n";
        debug_log += "Breathing In:" + breath_tracker.breathing_in.ToString() + "\n";
        debug_log += "Breathing Out:" + breath_tracker.breathing_out.ToString() + "\n";
        debug_log += "Breaths:" + breath_tracker.number_of_breaths.ToString() + "\n";
        debug_log += "Consecutive Breaths at Frequency:" + breath_tracker.correct_consecutive_breaths.ToString() + "\n";
        debug_log += "Consecutive Breaths not at Frequency:" + breath_tracker.incorrect_consecutive_breaths.ToString() + "\n";

        debug_text.text = debug_log;
    }
}
