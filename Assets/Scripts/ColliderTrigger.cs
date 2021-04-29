using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTrigger : MonoBehaviour
{
    private GameObject music;
    private Music musicScript;

    public bool Tutorial;
    public bool forest;
    public bool city;

    public event EventHandler OnPlayerEnterTriggerTutorial;
    public event EventHandler OnPlayerEnterTriggerForest;
    public event EventHandler OnPlayerEnterTriggerCity;

    void Start()
    {
        music = GameObject.Find("Music");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Debug.Log("Player insider trigger");
            if(Tutorial)
            {
                musicScript = music.GetComponent<Music>();

                musicScript.changeSong(2);

                OnPlayerEnterTriggerTutorial?.Invoke(this, EventArgs.Empty);
            }
            if (forest)
            {
                musicScript = music.GetComponent<Music>();

                musicScript.changeSong(3);

                OnPlayerEnterTriggerForest?.Invoke(this, EventArgs.Empty);
                    
                
                

            }
            if (city)
            {
                musicScript = music.GetComponent<Music>();

                musicScript.changeSong(3);

                OnPlayerEnterTriggerCity?.Invoke(this, EventArgs.Empty);

            }

        }

    }
}
