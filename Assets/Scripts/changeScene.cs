using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class changeScene : MonoBehaviour
{
    [SerializeField] private string newLevel;

    public void OnMouseUp()
    {
        SceneManager.LoadScene(newLevel);
        Debug.Log("Next Scene");
    }
}