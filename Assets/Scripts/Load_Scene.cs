using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_Scene : MonoBehaviour
{
    public void loadScene(string scene_name)
    {
        SceneManager.LoadScene(scene_name);
    }
}
