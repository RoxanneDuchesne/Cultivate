using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    public Transform player_body;
    public float movement_per_second = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player_body.position =
           new Vector3(player_body.position.x, player_body.position.y, player_body.position.z + movement_per_second * Time.deltaTime);
    }
}
