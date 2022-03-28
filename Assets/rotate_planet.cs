using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate_planet : MonoBehaviour
{
    public float rotation_factor = 1;
    public float rotation_vector_x = 0;
    public float rotation_vector_y = 1;
    public float rotation_vector_z = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(rotation_vector_x, rotation_vector_y, rotation_vector_z) * Time.deltaTime * rotation_factor);
    }
}
