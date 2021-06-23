using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMouseLook : MonoBehaviour
{
    [Range(0.0f, 1000.0f)]
    public float mouseSensitivity;

    private float mouseX;
    private float mouseY;
    private float xRot = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRot -= mouseY;
    }
}
