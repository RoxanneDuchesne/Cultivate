using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tunnel_Position_Controller : MonoBehaviour
{
    public GameObject camera_obj;

    public GameObject exit_menu_obj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        exit_menu_obj.transform.position = camera_obj.transform.position + new Vector3(0, 0, 10.0f);
    }
}
