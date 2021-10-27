using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Guiding_Stars : MonoBehaviour
{
    public float star_expansion_rate = 0.4f;

    public GameObject gold_star;
    public GameObject red_star;

    public GameObject breath_tracker_obj;

    public GameObject star_0;
    public GameObject star_1;
    public GameObject star_2;
    public GameObject star_3;
    public GameObject star_4;
    public GameObject star_5;
    public GameObject star_6;
    public GameObject star_7;
    public GameObject star_8;
    public GameObject star_9;
    public GameObject star_10;
    public GameObject star_11;
    public GameObject star_12;
    public GameObject star_13;
    public GameObject star_14;
    public GameObject star_15;
    public GameObject star_16;
    public GameObject star_17;
    public GameObject star_18;
    public GameObject star_19;
    public GameObject star_20;
    public GameObject star_21;
    public GameObject star_22;
    public GameObject star_23;

    private float radius;
    private float breath_start;
    private Controller_Breathing_Tracker breath_tracker;

    // Start is called before the first frame update
    void Start()
    {
        radius = 0.0f;
        breath_start = Time.time;

        breath_tracker = breath_tracker_obj.GetComponent<Controller_Breathing_Tracker>();
    }

    // Update is called once per frame                                                       
    void Update()
    {
        if ((Time.time - breath_start) < 5)
        {
            radius += Time.deltaTime * star_expansion_rate;
        }
        else if ((Time.time - breath_start) > 5 && (Time.time - breath_start) < 10)
        {
            radius -= Time.deltaTime * star_expansion_rate;
        }
        else
        {
            radius = 0.0f;
            breath_start = Time.time;
        }

        CalculateStarPosition(0, star_0);
        CalculateStarPosition(1, star_1);
        CalculateStarPosition(2, star_2);
        CalculateStarPosition(3, star_3);
        CalculateStarPosition(4, star_4);
        CalculateStarPosition(5, star_5);
        CalculateStarPosition(6, star_6);
        CalculateStarPosition(7, star_7);
        CalculateStarPosition(8, star_8);
        CalculateStarPosition(9, star_9);
        CalculateStarPosition(10, star_10);
        CalculateStarPosition(11, star_11);
        CalculateStarPosition(12, star_12);
        CalculateStarPosition(13, star_13);
        CalculateStarPosition(14, star_14);
        CalculateStarPosition(15, star_15);
        CalculateStarPosition(16, star_16);
        CalculateStarPosition(17, star_17);
        CalculateStarPosition(18, star_18);
        CalculateStarPosition(19, star_19);
        CalculateStarPosition(20, star_20);
        CalculateStarPosition(21, star_21);
        CalculateStarPosition(22, star_22);
        CalculateStarPosition(23, star_23);

        if (breath_tracker.correct_consecutive_breaths >= 3)
        {
            red_star.SetActive(false);
            gold_star.SetActive(true);
        }
        else
        {
            red_star.SetActive(true);
            gold_star.SetActive(false);
        }
    }

    private void CalculateStarPosition(int star_id, GameObject star)
    {
        float x_pos = radius * Mathf.Cos(star_id * 15);
        float y_pos = radius * Mathf.Sin(star_id * 15);

        star.transform.position = new Vector3(red_star.transform.position.x + x_pos, red_star.transform.position.y + y_pos, star.transform.position.z);
    }
}
