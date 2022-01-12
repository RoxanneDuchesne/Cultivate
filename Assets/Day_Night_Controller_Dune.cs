using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day_Night_Controller_Dune : MonoBehaviour
{
    public GameObject breath_tracker_obj;
    public Light light;

    private Controller_Breathing_Tracker breath_tracker;

    // Color Levels
    Color color_0 = new Color(0.1f, 0.1f, 0.5f, 0.1f);
    Color color_1 = new Color(0.1f, 0.1f, 1.0f, 0.1f);
    Color color_2 = new Color(0.31f, 0.22f, 0.53f, 0.1f);
    Color color_3 = new Color(0.75f, 0.43f, 0.58f, 0.1f);
    Color color_4 = new Color(0.65f, 0.57f, 0.55f, 0.1f);

    // Light Levels
    Color light_0 = new Color(0.1f, 0.1f, 0.5f, 0.1f);
    Color light_1 = new Color(0.1f, 0.1f, 1.0f, 0.1f);
    Color light_2 = new Color(0.31f, 0.22f, 0.53f, 0.1f);
    Color light_3 = new Color(0.75f, 0.43f, 0.58f, 0.1f);
    Color light_4 = Color.white;

    // Start is called before the first frame update
    void Start()
    {
        RenderSettings.skybox.SetColor("_Tint", color_0);
        light.color = color_0;
    }

    // Update is called once per frame
    void Update()
    {
        int current_level = breath_tracker.Get_Current_Level();

        switch (current_level)
        {
            case 1:
                RenderSettings.skybox.SetColor("_Tint", Color.Lerp(color_0, color_1, 20));
                light.color = Color.Lerp(color_0, color_1, 20);
                break;
            case 2:
                RenderSettings.skybox.SetColor("_Tint", Color.Lerp(color_1, color_2, 20));
                light.color = Color.Lerp(color_1, color_2, 20);
                break;
            case 3:
                RenderSettings.skybox.SetColor("_Tint", Color.Lerp(color_2, color_3, 20));
                light.color = Color.Lerp(color_2, color_3, 20);
                break;
            case 4:
                RenderSettings.skybox.SetColor("_Tint", Color.Lerp(color_3, color_4, 20));
                light.color = Color.Lerp(color_3, color_4, 20);
                break;
        }
    }
}
