using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairCursor : MonoBehaviour
{
    // Start is called before the first frame update
<<<<<<< Updated upstream
    void Awake()
    {
        Cursor.visible = false;
=======
    void Start()
    {
        
>>>>>>> Stashed changes
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
        Vector2 mouseCursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mouseCursorPos;
=======
        
>>>>>>> Stashed changes
    }
}
