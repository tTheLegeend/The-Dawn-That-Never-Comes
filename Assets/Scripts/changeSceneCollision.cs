using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeSceneCollision : MonoBehaviour
{
    bool bPressedF = false;

    [Tooltip("The Transform to teleport to")]
    [SerializeField] Transform teleportTo;

    [Tooltip("The filter Tag")]
    [SerializeField] string tag = "Player";

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
            if (tag == string.Empty || other.CompareTag(tag))

            {
                other.transform.position = teleportTo.position;
            }
                
            Debug.Log("Move Scene");
        }
    }
}

public class TeleportTrigger : MonoBehaviour
{
    public enum TriggerType 
    { 
        Enter, Exit 
    };



    //[Tooltip("Trigger Event to Teleport")]
    //[SerializeField] TriggerType type;

    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (type != TriggerType.Enter)
    //        return;

    //    if (tag == string.Empty || other.CompareTag(tag))
    //        other.transform.position = teleportTo.position;
    //}

    //void OnTriggerExit2D(Collider2D other)
    //{
    //    if (type != TriggerType.Exit)
    //        return;

    //    if (tag == string.Empty || other.CompareTag(tag))
    //        other.transform.position = teleportTo.position;
    //}
}