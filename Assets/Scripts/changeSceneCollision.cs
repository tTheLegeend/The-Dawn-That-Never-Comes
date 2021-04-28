using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeSceneCollision : MonoBehaviour
{
    [SerializeField] private string newLevel;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            SceneManager.LoadScene(newLevel);
            Debug.Log("Move Scene");
        }
    }
}
