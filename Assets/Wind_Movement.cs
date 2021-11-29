using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind_Movement : MonoBehaviour
{

    public GameObject breath_tracker_obj;
    public GameObject main_camera;
    public GameObject wind;
    private Controller_Breathing_Tracker breath_tracker;

    // Start is called before the first frame update
    void Start()
    {
        // if (breath_tracker.breathing_out)
        // {
        //    wind.transform.position = main_camera.transform.position;
        //}

        wind.transform.position = main_camera.transform.position;
        wind.transform.position -= new Vector3(0, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {

       // wind.transform.position = main_camera.transform.position;
    }
}

