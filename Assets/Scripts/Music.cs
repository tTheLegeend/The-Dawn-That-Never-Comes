using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioClip battle;
    public AudioClip calmMusic;
    public AudioClip nightTime;
    public int songNumber;
    private int temp;
    AudioSource audioData;

    // Start is called before the first frame update
    void Start()
    {
        audioData = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioData.isPlaying || temp != songNumber)
        {
            switch (songNumber)
            {
                case 1:
                    audioData.PlayOneShot(battle, 0.7f);
                    temp = 1;
                    break;
                case 2:
                    audioData.PlayOneShot(calmMusic, 0.7f);
                    temp = 2;
                    break;
                case 3:
                    audioData.PlayOneShot(nightTime, 0.7f);
                    temp = 3;
                    break;
                default:
                    audioData.Stop();
                    break;
            }
        }
    }

    public void changeSong(int songChoice)
    {
        songNumber = songChoice;
    }
}
