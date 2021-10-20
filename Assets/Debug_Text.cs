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
        debug_text.text = "Hellow";
    }
}
