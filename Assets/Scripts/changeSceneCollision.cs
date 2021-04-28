using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeSceneCollision : MonoBehaviour
{
    [SerializeField] private string newLevel;
    bool bPressedF = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            bPressedF = true;
            Debug.Log("F was pressed");
        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.name == "Player" && bPressedF == true)
        {
            SceneManager.LoadScene(newLevel);
            Debug.Log("Move Scene");
        }
    }
}
