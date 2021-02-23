
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 10f;
    public float panBorderThickness = 10f;
    public Vector2 panLimit;

    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    
    
    void Update()
    {
        Vector3 pos = transform.position;
        

        if (Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            pos.y += panSpeed * Time.deltaTime;
        }
        if (Input.mousePosition.y <= panBorderThickness)
        {
            pos.y -= panSpeed * Time.deltaTime;
        }
        if(Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            pos.x += panSpeed * Time.deltaTime;
        }
        if(Input.mousePosition.x <= panBorderThickness)
        {
            pos.x -= panSpeed * Time.deltaTime;
        }


        

        pos.x = Mathf.Clamp(pos.x, GameObject.FindGameObjectWithTag("Player").transform.position.x - panLimit.x, GameObject.FindGameObjectWithTag("Player").transform.position.x + panLimit.x);
        pos.y = Mathf.Clamp(pos.y, GameObject.FindGameObjectWithTag("Player").transform.position.y - panLimit.y, GameObject.FindGameObjectWithTag("Player").transform.position.y + panLimit.y);

        transform.position = pos;
    }

    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}
