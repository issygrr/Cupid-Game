using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFPS : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public GameObject player;
    public GameObject weapon;
    private float mouseX;
    private float mouseY;
    float xRot;
    // add clamp for grouncheck
    public void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    // Update is called once per frame
    public void Update()

    {
        mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity;
        mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity;

        transform.Rotate(-mouseY, 0f, 0f, Space.Self);
        transform.Rotate(0f, mouseX, 0f, Space.World);
        player.transform.Rotate(0f, mouseX, 0f, Space.World);
        weapon.transform.Rotate(-mouseY, 0f, 0f, Space.Self);
        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -30f, 90f);
        transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);

       
    }
}
