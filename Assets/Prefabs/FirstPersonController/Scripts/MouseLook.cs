using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    Vector3 rotation = Vector3.zero;
    public float speed = 3;
    public float maxRotation = 20;
    Vector3 defaultRotation;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        defaultRotation = transform.eulerAngles;
    }

    void Update()
    {
        rotation.y += Input.GetAxis("Mouse X");
        transform.eulerAngles = new Vector3(0, rotation.y * speed, 0) + defaultRotation;


        rotation.x += Input.GetAxis("Mouse Y");
        rotation.x = Mathf.Clamp(rotation.x, -maxRotation, maxRotation);
        Camera.main.transform.localEulerAngles = new Vector3(-rotation.x * speed, 0, 0);

    }
}
