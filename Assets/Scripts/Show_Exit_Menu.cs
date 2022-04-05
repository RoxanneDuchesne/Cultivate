using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Show_Exit_Menu : MonoBehaviour
{
    public GameObject exit_menu;
    public GameObject laser_pointer;

    // Start is called before the first frame update
    void Start()
    {
        exit_menu.SetActive(false);
        laser_pointer.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       if(OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.LTouch) || OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.LTouch) 
            || OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch) || OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.RTouch))
        {
            exit_menu.SetActive(true);
            laser_pointer.SetActive(true);
        }
    }
}
