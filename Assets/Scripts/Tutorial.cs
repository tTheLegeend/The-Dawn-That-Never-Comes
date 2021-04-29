using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Tutorial : MonoBehaviour
{
    public Canvas canvas;
    public Text text;
    public bool startTimer;
    public float timeValue;
    [SerializeField]
    private ColliderTrigger colliderTriggerTutorial;
     void Start()
    {
        canvas.gameObject.SetActive(false);
        colliderTriggerTutorial.OnPlayerEnterTriggerTutorial += ColliderTrigger_OnPlayerEnterTriggerTutorial;

    }

    private void ColliderTrigger_OnPlayerEnterTriggerTutorial(object sender, System.EventArgs e)
    {

        startTutorial();

    }
    private void Update()
    {
        if ( GameManager.Instance.inventorySlots[2].isFull)
        {
            part2();
        }
        if ( GameManager.Instance.inventorySlots[0].isFull)
        {
            part3();
        }
        if(startTimer)
        {
            timeValue -= Time.deltaTime;
        }
        if(timeValue <= 0)
        {
            canvas.gameObject.SetActive(false);
        }
    }

    public void startTutorial()
    {
        canvas.gameObject.SetActive(true);
        Debug.Log("tutorial");

        text.text = "Go pick up that baseball bat. Press e to pick it up ";


    }

    public void part2()
    {
        text.text = "Press i to open inventory and drag weapon into the weapon slot to use your weapon";
    }

    public void part3()
    {
        text.text = "Now Press F at the door to leave. Good Luck...";
        startTimer = true;
    }
}
