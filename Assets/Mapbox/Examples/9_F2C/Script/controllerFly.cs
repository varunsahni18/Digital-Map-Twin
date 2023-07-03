using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controllerFly : MonoBehaviour
{
    [Tooltip("MOVEMNTSPEED")]
    public float SpeedMovement = 100f;
    [Tooltip("ROTATESPEED")]
    public float speedRotate = 10f;

    public float minHeight = 2f;
    public float maxHeight = 500f;
    public float minRot = 0f;
    public float maxRot = 90f;
    private float MII;
     private float vid;
     private float raj;
    //public float xRotate = 0 ;
    // public float yRotate = 90f;


    private void Awake()
    {
        MII = transform.eulerAngles.y;
        vid = transform.eulerAngles.x;
        raj = transform.eulerAngles.z;

    }

    // Update is called once per frame
    public void Update()
    {
        bool pressW = Input.GetKey(KeyCode.W);
        bool pressA = Input.GetKey(KeyCode.A);
        bool pressD = Input.GetKey(KeyCode.D);
        bool pressS = Input.GetKey(KeyCode.S);
        bool pressQ = Input.GetKey(KeyCode.Q);
        bool pressE = Input.GetKey(KeyCode.E);
        bool pressUp = Input.GetKey(KeyCode.UpArrow);
        bool pressDown = Input.GetKey(KeyCode.DownArrow);
        bool pressLeft = Input.GetKey(KeyCode.LeftArrow);
        bool pressRight = Input.GetKey(KeyCode.RightArrow);



        bool isMoving = pressW || pressS || pressD || pressA||pressE||pressQ;
        bool isRotating = pressLeft || pressRight || pressUp || pressDown;
        if (!isMoving && !isRotating)
        {
            return;
        }

        float zinput = pressA ? -1 : pressD ? 1 : 0;
        float yInput = pressQ ? 1 : pressE ? -1 : 0;
        float xinput = pressW ? 1 : pressS ? -1 : 0;
        float xRotat = pressLeft ? 1 : pressRight ? -1 : 0;
        float yRotat = pressUp ? -1 : pressDown ? 1 : 0;

        //  float z = 0:0:0;
        Vector3 positionBefore = transform.position;
        if (isMoving)
        {
            float speed = Mathf.Clamp(transform.position.y, SpeedMovement * 0.01f, SpeedMovement);
            Vector3 forward = Quaternion.Euler(0, vid, 0) * Vector3.forward;
            Vector3 right = Quaternion.Euler(0, vid, 0) * Vector3.right;
            Vector3 motion = (right * xinput + forward * zinput + yInput * Vector3.up) * speed * Time.deltaTime;
            Vector3 position = transform.position + motion;
            position.y = Mathf.Clamp(position.y, minHeight, maxHeight);
            transform.position = position;
        }

        if (isRotating)
        {
            vid += xRotat * speedRotate * Time.deltaTime;
            // MII += yRotat * speedRotate * Time.deltaTime;
            MII = Mathf.Clamp(MII + yRotat * speedRotate * Time.deltaTime, minRot, maxRot);

            transform.localRotation = Quaternion.Euler(vid, MII, 0);
        }




    }
}
