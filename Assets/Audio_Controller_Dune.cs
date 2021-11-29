using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Controller_Dune : MonoBehaviour
{
    public GameObject breath_tracker_obj;
    public AudioSource audio_1;
    public AudioSource audio_2;
    public AudioSource audio_3;
    public AudioSource audio_4;
    public AudioSource audio_base;

    private Controller_Breathing_Tracker breath_tracker;

    // Start is called before the first frame update
    void Start()
    {
        breath_tracker = breath_tracker_obj.GetComponent<Controller_Breathing_Tracker>();

        audio_base.Play(0);
        audio_1.Stop();
        audio_2.Stop();
        audio_3.Stop();
        audio_4.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        int current_level = breath_tracker.Get_Current_Level();

        bool is_audio_playing = Is_Audio_Playing();

        if(!is_audio_playing)
        {
            switch(current_level)
            {
                case 1:
                    audio_1.Play(0);
                    break;
                case 2:
                    audio_2.Play(0);
                    break;
                case 3:
                    audio_3.Play(0);
                    break;
                case 4:
                    audio_4.Play(0);
                    break;
            }
        }
    }

    private bool Is_Audio_Playing()
    {
        if (audio_1.isPlaying || audio_2.isPlaying || audio_3.isPlaying || audio_4.isPlaying)
        {
            return true;
        }

        return false;
    }
}
