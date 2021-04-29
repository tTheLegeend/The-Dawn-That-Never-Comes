using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTrigger : MonoBehaviour
{
    public bool Tutorial;
    public bool forest;
    public bool city;

    public event EventHandler OnPlayerEnterTriggerTutorial;
    public event EventHandler OnPlayerEnterTriggerForest;
    public event EventHandler OnPlayerEnterTriggerCity;

    

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Debug.Log("Player insider trigger");
            if(Tutorial)
            {
                OnPlayerEnterTriggerTutorial?.Invoke(this, EventArgs.Empty);
            }
            if (forest)
            {
                
                        OnPlayerEnterTriggerForest?.Invoke(this, EventArgs.Empty);
                    
                
                

            }
            if (city)
            {
                OnPlayerEnterTriggerCity?.Invoke(this, EventArgs.Empty);

            }

        }

    }
}
