using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day_Night_Controller_Dune : MonoBehaviour
{
    public GameObject breath_tracker_obj;
    public Light light;

    private Controller_Breathing_Tracker breath_tracker;

    // Color Levels
    Color color_0 = new Color(0, 0, 0);
    Color color_1 = new Color(1, 1, 1);

    // Light Levels


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //RenderSettings.skybox.SetColor("_Tint", color_1);
        light.color = Color.Lerp(color_0, color_1, 10);
    }
}
