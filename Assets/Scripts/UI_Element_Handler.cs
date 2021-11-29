using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Element_Handler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Button button;
    public AudioSource hover;
    public Sprite select_image;
    public Sprite unselect_image;
    public string scene_name;

    private bool mouse_over = false;
    void Update()
    {
        if (mouse_over)
        {
            Debug.Log("Mouse Over");
            if (OVRInput.GetDown(OVRInput.Button.Any, OVRInput.Controller.LTouch) || OVRInput.GetDown(OVRInput.Button.Any, OVRInput.Controller.RTouch))
            {
                SceneManager.LoadScene(scene_name);
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouse_over = true;
        Debug.Log("Mouse enter");

        button.GetComponent<Image>().sprite = select_image;
        hover.Play(0);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouse_over = false;
        Debug.Log("Mouse exit");

        button.GetComponent<Image>().sprite = unselect_image;
    }
}

