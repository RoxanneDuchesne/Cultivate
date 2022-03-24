using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tunnel_Controller : MonoBehaviour
{
    public GameObject tunnel_obj;
    private TunnelEffect.TunnelFX2 tunnel;

    public GameObject breath_tracker_obj;
    private Controller_Breathing_Tracker breath_tracker;

    public GameObject camera_obj;
    private OVRCameraRig camera;

    private int correct_breath_count;

    private float tunnel_speed;
    private float distance_to_tunnel_end;

    public float MAX_SPEED = 3.0f;
    public float MIN_SPEED = 0.1f;
    public float SPEED_INCREMENT = 0.4f;
    public float SPEED_DECREMENT = 0.2f;

    public float TUNNEL_LENGTH = 100.0f;

    public float REDUCE_TUNNEL_FREQUENCY = 0.0004f;
    public float TUNNEL_EXIT_SPEED = 200.0f;
    public float FINAL_Z_POSITION = 270.0f;

    // Start is called before the first frame update
    void Start()
    {
        breath_tracker = breath_tracker_obj.GetComponent<Controller_Breathing_Tracker>();
        tunnel = tunnel_obj.GetComponent<TunnelEffect.TunnelFX2>();
        camera = camera_obj.GetComponent<OVRCameraRig>();

        tunnel.hyperSpeed = 0.0f;
        tunnel.layersSpeed = 0.1f;

        distance_to_tunnel_end = TUNNEL_LENGTH;
    }

    // Update is called once per frame
    void Update()
    {
        Exit_Tunnel();

        if (distance_to_tunnel_end <= 0)
        {
            Exit_Tunnel();
            return;
        }

        if (correct_breath_count != breath_tracker.correct_consecutive_breaths)
        {
            Update_Speed();
        }

        distance_to_tunnel_end -= tunnel_speed * Time.deltaTime;
    }

    void Update_Speed()
    {
        if (correct_breath_count > breath_tracker.correct_consecutive_breaths)
        {
            if (tunnel_speed < MAX_SPEED)
            {
                tunnel_speed += SPEED_INCREMENT;
            }
        }
        else
        {
            if (tunnel_speed > (MIN_SPEED + SPEED_DECREMENT))
            {
                tunnel_speed -= SPEED_DECREMENT;
            }
        }

        correct_breath_count = breath_tracker.correct_consecutive_breaths;
        tunnel.layersSpeed = tunnel_speed;
    }

    void Exit_Tunnel()
    {
        if (tunnel.curvedTunnelFrequency > 0.0f)
        {
            tunnel.curvedTunnelFrequency -= REDUCE_TUNNEL_FREQUENCY * Time.deltaTime;
        }
        else
        {
            tunnel.curvedTunnel = false;
            tunnel.animationAmplitude = 0.01f;
            
            if (camera.transform.position.z < FINAL_Z_POSITION)
            {
                camera.transform.position = camera.transform.position + new Vector3(0, 0, TUNNEL_EXIT_SPEED * Time.deltaTime);
            }
            else
            {
                tunnel.enabled = false;
            }
        }
    }
}
