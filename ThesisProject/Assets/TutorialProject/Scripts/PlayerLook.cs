using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] public int mouseSensitivity;
    public Transform playerCamera;

    private float xRotation, yRotation;
    private float mouseX, mouseY;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = mouseX * Time.deltaTime * mouseSensitivity;
        mouseY = mouseY * Time.deltaTime * mouseSensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -35f, 40f);
        yRotation += mouseX;

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        playerCamera.rotation = Quaternion.Euler(xRotation, yRotation, 0);
    }

    private void OnLook(InputValue input)
    {
        mouseX = input.Get<Vector2>().x;
        mouseY = input.Get<Vector2>().y;
    }
}
