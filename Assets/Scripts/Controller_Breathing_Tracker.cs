using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Breathing_Tracker : MonoBehaviour
{

    //public GameObject camera;

    //public GameObject left_controller, right_controller;

    //Tuning Variables
    static public int frames_in_short_moving_avg = 10;
    static public int frames_in_long_moving_avg = 90;

    public float resonance_frequency_s = 10.0f;
    public float resonance_frequency_buffer_s = 0.5f;

    public float movement_noise_buffer = 0.05f;

    static public int number_of_breaths_to_record = 10;

    //Info Variables
    public bool calibrated = false;

    public bool breathing_in = false;
    public bool breathing_out = false;

    public bool breathing_at_resonance_frequency = false;

    public int correct_consecutive_breaths = 0;
    public int incorrect_consecutive_breaths = 0;

    public int previous_correct_consecutuve_breaths = 0;
    public int previous_incorrect_consecutive_breaths = 0;

    //Private Variables
    private int frames_to_calibration = frames_in_long_moving_avg;

    private LinkedList<Vector3> position_trend_left_touch = new LinkedList<Vector3>();
    private LinkedList<Vector3> position_trend_right_touch = new LinkedList<Vector3>();
    private LinkedList<Quaternion> rotation_trend_left_touch = new LinkedList<Quaternion>();
    private LinkedList<Quaternion> rotation_trend_right_touch = new LinkedList<Quaternion>();

    private Vector3 short_moving_average_left_touch;
    private Vector3 short_moving_average_right_touch;

    private Vector3 long_moving_average_left_touch;
    private Vector3 long_moving_average_right_touch;

    private double breath_start_time = -1;

    private int[] breath_length = new int[number_of_breaths_to_record];


    void Start()
    {
        Recalibrate();
    }

    // Update is called once per frame
    void Update()
    {

        //Controller tracking
        Vector3 position_left_touch = OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch);
        Vector3 position_right_touch = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);

        Quaternion rotation_left_touch = OVRInput.GetLocalControllerRotation(OVRInput.Controller.LTouch);
        Quaternion rotation_right_touch = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch);

        position_trend_left_touch.AddFirst(position_left_touch);
        position_trend_right_touch.AddFirst(position_right_touch);
        rotation_trend_left_touch.AddFirst(rotation_left_touch);
        rotation_trend_right_touch.AddFirst(rotation_right_touch);

        //Calibration
        if (frames_to_calibration > 0)
        {
            frames_to_calibration--;
            return;
        }

        position_trend_left_touch.RemoveLast();
        position_trend_right_touch.RemoveLast();
        rotation_trend_left_touch.RemoveLast();
        rotation_trend_right_touch.RemoveLast();

        short_moving_average_left_touch = CalculateMovingAverage(frames_in_short_moving_avg, ref position_trend_left_touch);
        short_moving_average_right_touch = CalculateMovingAverage(frames_in_short_moving_avg, ref position_trend_right_touch);
        long_moving_average_left_touch = CalculateMovingAverage(frames_in_long_moving_avg, ref position_trend_left_touch);
        long_moving_average_right_touch = CalculateMovingAverage(frames_in_long_moving_avg, ref position_trend_right_touch);


        //Check for rotation

        //if so recalibrate

        //Check for large movements

        //if so recalibrate


        if (calibrated == false)
        {
            OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.RTouch);

            calibrated = true;
        }

        //Calculate breathing in or out

        float breathe_direction = short_moving_average_right_touch.x - long_moving_average_right_touch.x;

        if (breathe_direction > movement_noise_buffer)
        {
            //Track breathing from start of breath
            if (breathing_in == false)
            {
                TrackBreath();
            }

            breathing_in = true;
            breathing_out = false;
        }
        else if (breathe_direction < -movement_noise_buffer)
        {
            breathing_in = false;
            breathing_out = true;
        }
        else
        {
            breathing_in = false;
            breathing_out = false;
        }

    }

    private void Recalibrate()
    {
        frames_to_calibration = frames_in_long_moving_avg;

        position_trend_left_touch = new LinkedList<Vector3>();
        position_trend_right_touch = new LinkedList<Vector3>();

        calibrated = false;
        breathing_in = false;
        breathing_out = false;
        breathing_at_resonance_frequency = false;
        breath_start_time = -1;
}

    private Vector3 CalculateMovingAverage(int frames_in_moving_avg, ref LinkedList<Vector3> position_trend_touch)
    {
        float moving_sum_z = 0;
        float moving_sum_y = 0;
        float moving_sum_x = 0;

        int frame_counter = 0;

        //Calculate smoothing average for controller position
        foreach (Vector3 position in position_trend_touch)
        {
            if (frame_counter >= frames_in_moving_avg)
            {
                break;
            }

            moving_sum_z += position.z;
            moving_sum_y += position.y;
            moving_sum_x += position.x;

            frame_counter++;
        }


        float moving_avg_z = moving_sum_z / frames_in_moving_avg;
        float moving_avg_y = moving_sum_y / frames_in_moving_avg;
        float moving_avg_x = moving_sum_x / frames_in_moving_avg;

        return new Vector3(moving_avg_z, moving_avg_y, moving_avg_x);
    }

    private void TrackBreath()
    {

        double current_time = Time.timeAsDouble;

        if (breath_start_time < 0)
        {
            breath_start_time = current_time;
            return;
        }

        double breath_length = current_time - breath_start_time;

        //Track if user is breathing at resonace frequency
        if (breath_length >= resonance_frequency_s - resonance_frequency_buffer_s && breath_length <= resonance_frequency_s + resonance_frequency_buffer_s)
        {
            correct_consecutive_breaths++;

            if (incorrect_consecutive_breaths > 0)
            {
                previous_incorrect_consecutive_breaths = incorrect_consecutive_breaths;
                incorrect_consecutive_breaths = 0;
            }
        }
        else
        {
            incorrect_consecutive_breaths++;

            if (correct_consecutive_breaths > 0)
            {
                previous_correct_consecutuve_breaths = correct_consecutive_breaths;
                correct_consecutive_breaths = 0;
            }
        }


        breath_start_time = current_time;

    }

}
