using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float mouseSenivity = 100f;
    Transform playerBody;
    float xRotation = 0f;


    // Start is called before the first frame update
    void Start()
    {
        playerBody = transform.parent;
        //To wyłącza kursor myszki w naszej grze
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    // Update is called once per frame
    void Update()
    {
        CameraRotation();
    }

    private void CameraRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSenivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSenivity * Time.deltaTime;


        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 80f);
        //Obracamy naszą kamerą góra/dół
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        //Obracamy całym graczem dookoła osi Z
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
