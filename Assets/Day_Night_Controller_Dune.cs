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
    Color color_1 = new Color(0.25f, 0.1f, 1.0f, 0.1f);
    Color color_2 = new Color(0.31f, 0.22f, 0.53f, 0.1f);
    Color color_3 = new Color(0.75f, 0.43f, 0.58f, 0.1f);
    Color color_4 = new Color(0.65f, 0.57f, 0.55f, 0.1f);

    // Light Levels
    Color light_0 = new Color(0.1f, 0.1f, 0.5f, 0.1f);
    Color light_1 = new Color(0.3f, 0.1f, 1.0f, 0.1f);
    Color light_2 = new Color(0.31f, 0.22f, 0.53f, 0.1f);
    Color light_3 = new Color(0.75f, 0.43f, 0.58f, 0.1f);
    Color light_4 = Color.white;

    private int previous_level = 0;

    float interpolation_rate = 0;

    // Start is called before the first frame update
    void Start()
    {
        RenderSettings.skybox.SetColor("_Tint", color_0);
        breath_tracker = breath_tracker_obj.GetComponent<Controller_Breathing_Tracker>();
        light.color = light_0;
    }

    // Update is called once per frame
    void Update()
    {
        int current_level = breath_tracker.Get_Current_Level();

        if (current_level > previous_level)
        {
            interpolation_rate += Time.deltaTime / 10.0f;

            switch (current_level)
            {
                case 1:
                    RenderSettings.skybox.SetColor("_Tint", Color.Lerp(color_0, color_1, interpolation_rate));
                    light.color = Color.Lerp(light_0, light_1, interpolation_rate);
                    break;
                case 2:
                    RenderSettings.skybox.SetColor("_Tint", Color.Lerp(color_1, color_2, interpolation_rate));
                    light.color = Color.Lerp(light_1, light_2, interpolation_rate);
                    break;
                case 3:
                    RenderSettings.skybox.SetColor("_Tint", Color.Lerp(color_2, color_3, interpolation_rate));
                    light.color = Color.Lerp(light_2, light_3, interpolation_rate);
                    break;
                case 4:
                    RenderSettings.skybox.SetColor("_Tint", Color.Lerp(color_3, color_4, interpolation_rate));
                    light.color = Color.Lerp(light_3, light_4, interpolation_rate);
                    break;
            }

            if (interpolation_rate > 1)
            {
                interpolation_rate = 0;
                previous_level = current_level;
            }
        }
        else if (current_level < previous_level)
        {
            interpolation_rate += Time.deltaTime / 5.0f;

            switch (current_level)
            {
                case 0:
                    RenderSettings.skybox.SetColor("_Tint", Color.Lerp(color_1, color_0, interpolation_rate));
                    light.color = Color.Lerp(light_1, light_0, interpolation_rate);
                    break;
                case 1:
                    RenderSettings.skybox.SetColor("_Tint", Color.Lerp(color_2, color_1, interpolation_rate));
                    light.color = Color.Lerp(light_2, light_1, interpolation_rate);
                    break;
                case 2:
                    RenderSettings.skybox.SetColor("_Tint", Color.Lerp(color_3, color_2, interpolation_rate));
                    light.color = Color.Lerp(light_3, light_2, interpolation_rate);
                    break;
                case 3:
                    RenderSettings.skybox.SetColor("_Tint", Color.Lerp(color_4, color_3, interpolation_rate));
                    light.color = Color.Lerp(light_4, light_3, interpolation_rate);
                    break;
            }

            if (interpolation_rate > 1)
            {
                interpolation_rate = 0;
                previous_level = current_level;
            }
        }
    }
}
