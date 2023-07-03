using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    
public class mouseLook : MonoBehaviour
{
    public float mouseSensitive=100f;
    public Transform playerbody;
    public float xrotation=0f;

    public mouseLook(Transform playerbody)
    {
        this.playerbody = playerbody;
    }


    // Start is called before the first frame update
    void Start()
    {
       // Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        xrotation -= mouseY;
        xrotation = Mathf.Clamp(xrotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xrotation, 0f, 0f);
        playerbody.Rotate(Vector3.up * mouseX);

    }
}
