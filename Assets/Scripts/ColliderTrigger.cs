using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTrigger : MonoBehaviour
{
    public bool forest;
    public bool city;


    public event EventHandler OnPlayerEnterTrigger;
    public event EventHandler OnPlayerEnterTriggerCity;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player insider trigger");
            if (forest)
            {
                OnPlayerEnterTrigger?.Invoke(this, EventArgs.Empty);

            }
            if (city)
            {
                OnPlayerEnterTriggerCity?.Invoke(this, EventArgs.Empty);

            }

        }

    }
}
