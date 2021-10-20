using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using System;
using UnityEngine;
using Unity.VisualScripting;

public class Hovl_DemoLasers : MonoBehaviour
{
    public GameObject FirePoint;
    public float MaxLength;
    public GameObject[] Prefabs;

    public GameObject EndPoint;

    private Ray RayMouse;
    private Vector3 direction;
    private Quaternion rotation;

    [Header("GUI")]
    private float windowDpi;

    private int Prefab;
    private GameObject Instance;
    private Hovl_Laser LaserScript;
    private Hovl_Laser2 LaserScript2;



    void Start ()
    {
        //LaserEndPoint = new Vector3(0, 0, 0);
        if (Screen.dpi < 1) windowDpi = 1;
        if (Screen.dpi < 200) windowDpi = 1;
        else windowDpi = Screen.dpi / 200f;
        Counter(0);

        Instance = Instantiate(Prefabs[Prefab], FirePoint.transform.position, FirePoint.transform.rotation);
        Instance.transform.parent = transform;
        LaserScript = Instance.GetComponent<Hovl_Laser>();
        LaserScript2 = Instance.GetComponent<Hovl_Laser2>();
    }

    void Update()
    {
 

        RotateToMouseDirection(FirePoint, EndPoint.transform.position);
        //LaserEndPoint = EndPoint.transform.position;
        /*Current fire point
        if (Cam != null)
        {
           // Vector3 hit = new Vector3(0.5f, 0.5f, 0.5f); //DELATE THIS IF YOU WANT TO USE LASERS IN 2D
            RotateToMouseDirection(gameObject, end_point.transform.position);
            /*
            var mousePos = Input.mousePosition;
            RayMouse = Cam.ScreenPointToRay(mousePos);
            //ADD THIS IF YOU WANT TO USE LASERS IN 2D: RaycastHit2D hit = Physics2D.Raycast(RayMouse.origin, RayMouse.direction, MaxLength);
            if (Physics.Raycast(RayMouse.origin, RayMouse.direction, out hit, MaxLength)) //CHANGE THIS IF YOU WANT TO USE LASERRS IN 2D: if (hit.collider != null)
            {
                RotateToMouseDirection(gameObject, hit.point);
                //LaserEndPoint = hit.point;
            }
            else
            {
                var pos = RayMouse.GetPoint(MaxLength);
                RotateToMouseDirection(gameObject, pos);
                //LaserEndPoint = pos;
            }
        }
        else
        {
            Debug.Log("No camera");
        }
        
        }
        */
    }

    //GUI Text
    void OnGUI()
    {
       // GUI.Label(new Rect(10 * windowDpi, 5 * windowDpi, 400 * windowDpi, 20 * windowDpi), "Use the keyboard buttons A/<- and D/-> to change lazers!");
       // GUI.Label(new Rect(10 * windowDpi, 20 * windowDpi, 400 * windowDpi, 20 * windowDpi), "Use left mouse button for shooting!");
    }

    //To change prefabs (count - prefab number)
    void Counter(int count)
    {
        Prefab += count;
        if (Prefab > Prefabs.Length - 1)
        {
            Prefab = 0;
        }
        else if (Prefab < 0)
        {
            Prefab = Prefabs.Length - 1;
        }
    }
  
    //To rotate fire point
    void RotateToMouseDirection (GameObject obj, Vector3 destination)
    {
        direction = destination - obj.transform.position;
        //direction = destination;
        rotation = Quaternion.LookRotation(direction);     
        obj.transform.localRotation = Quaternion.Lerp(obj.transform.rotation, rotation, 1);
    }
}
