using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFPS : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public GameObject player;

    // Update is called once per frame
    public void Update()
    {
        transform.Rotate(Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity, 0, 0);
        player.transform.Rotate(Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity, 0, 0);
    }
}
