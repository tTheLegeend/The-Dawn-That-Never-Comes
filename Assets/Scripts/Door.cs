using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject doorOpen;

    bool bPressedF = false;

    private PlayerMovement thePlayer;

    public SpriteRenderer theSR;
    public Sprite house_outside_open;

    public bool doorOpen1, waitingToOpen;

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerMovement>();
        doorOpen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(waitingToOpen)
        {
            if(Vector3.Distance(thePlayer.followingKey.transform.position, transform.position) <0.1f)
            {
                waitingToOpen = false;

                doorOpen1 = true;

                theSR.sprite = house_outside_open;

                thePlayer.followingKey.gameObject.SetActive(false);
                thePlayer.followingKey = null;
                doorOpen.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            bPressedF = true;
            Debug.Log("F was pressed");
        }

        if (doorOpen && Vector3.Distance(thePlayer.transform.position, transform.position) < 1f && Input.GetKeyDown(KeyCode.F))
        {

            Debug.Log("Move Scene");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if(thePlayer.followingKey != null)
            {
                thePlayer.followingKey.followTarget = transform;
                waitingToOpen = true;
            }
        }
    }
}
