using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTrigger : MonoBehaviour
{



    public event EventHandler OnPlayerEnterTrigger;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player insider trigger");
            OnPlayerEnterTrigger?.Invoke(this, EventArgs.Empty);
        }

    }
}
