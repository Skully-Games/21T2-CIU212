using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace John
{
    public class MouseLook : MonoBehaviour
    {
        public float mouseSensitivity = 100f;
        public Transform playerBody;
        private float XRotation = 0f;
        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
     
        void Update()
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            XRotation -= mouseY;
            XRotation = Mathf.Clamp(XRotation, -90f, 90f);
            playerBody.Rotate(Vector3.up * mouseX);
            transform.localRotation = Quaternion.Euler(XRotation,0f,0f);
        
        }
    }  
}

