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

    public GameObject fog;

    private int correct_breath_count;

    private float tunnel_speed;
    private float distance_to_tunnel_end;

    public float MAX_SPEED = 3.0f;
    public float MIN_SPEED = 0.1f;
    public float SPEED_INCREMENT = 0.4f;
    public float SPEED_DECREMENT = 0.2f;

    public float TUNNEL_LENGTH = 100.0f;

    public float REDUCE_TUNNEL_FREQUENCY = 0.0004f;
    public float TUNNEL_EXIT_SPEED = 100.0f;
    public float EXIT_Z_POSITION = 300.0f;

    private float EXIT_X = 76.5f;
    private float EXIT_Y = 78.0f;
    private float EXIT_ADJUSTMENT_SPEED = 3.0f;

    private bool slow_down = false;
    float begin_slowdown_timestamp;

    private bool moving = true;

    // Start is called before the first frame update
    void Start()
    {
        breath_tracker = breath_tracker_obj.GetComponent<Controller_Breathing_Tracker>();
        tunnel = tunnel_obj.GetComponent<TunnelEffect.TunnelFX2>();
        camera = camera_obj.GetComponent<OVRCameraRig>();

        tunnel.hyperSpeed = 0.0f;
        tunnel.layersSpeed = 0.1f;

        distance_to_tunnel_end = TUNNEL_LENGTH;

        fog.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       // Exit_Tunnel();

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
            fog.SetActive(true);

            tunnel.curvedTunnelFrequency -= REDUCE_TUNNEL_FREQUENCY * Time.deltaTime;
        }
        else
        {
            tunnel.curvedTunnel = false;
            tunnel.animationAmplitude = 0.01f;

            // Adjust x and y to center player when exiting tunnel

            float exit_x_adjustment = camera.transform.position.x + (EXIT_ADJUSTMENT_SPEED * Time.deltaTime);
            float exit_y_adjustment = camera.transform.position.y + (EXIT_ADJUSTMENT_SPEED * Time.deltaTime);

            if (exit_x_adjustment < EXIT_X)
            {
                camera.transform.position = camera.transform.position + new Vector3((EXIT_ADJUSTMENT_SPEED * Time.deltaTime), 0, 0);
            }
            else
            {
                camera.transform.position = new Vector3(EXIT_X, camera.transform.position.y, camera.transform.position.z);
            }

            if (exit_y_adjustment < EXIT_Y)
            {
                camera.transform.position = camera.transform.position + new Vector3(0, (EXIT_ADJUSTMENT_SPEED * Time.deltaTime), 0);
            }
            else
            {
                camera.transform.position = new Vector3(camera.transform.position.x, EXIT_Y, camera.transform.position.z);
            }


            if (camera.transform.position.z < EXIT_Z_POSITION)
            {
                camera.transform.position = camera.transform.position + new Vector3(0, 0, TUNNEL_EXIT_SPEED * Time.deltaTime);
            }
            else if (moving)
            {
                if (slow_down == false)
                {
                    tunnel_obj.SetActive(false);
                    fog.SetActive(false);

                    slow_down = true;
                    // Determine slowdown using exponential decay
                    begin_slowdown_timestamp = (float)Time.timeAsDouble;
                }

                float decay_constant = 0.5f;
                float position_delta = 100;
                float position_adjustment = ((position_delta) * (float)System.Math.Exp(-(decay_constant * ((float)Time.timeAsDouble - begin_slowdown_timestamp))));

                camera.transform.position = camera.transform.position + new Vector3(0, 0, position_adjustment * Time.deltaTime);

                if (position_adjustment < 0.5f)
                {
                    moving = false;
                }
            }
        }
    }
}
