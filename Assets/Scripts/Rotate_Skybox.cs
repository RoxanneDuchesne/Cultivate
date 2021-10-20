using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_Skybox : MonoBehaviour
{
    public float rotation_speed = 1.2f;

    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * rotation_speed);
    }
}
