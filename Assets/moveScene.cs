using UnityEngine;
using UnityEngine.SceneManagement;


public class nextScene : MonoBehaviour
{
    [SerializeField] private string newLevel;

    void OnMouseUp()
    {
        SceneManager.LoadScene(newLevel);
    }
}