using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
{
    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Translate(new Vector3(-speed, 0, 0) * Time.deltaTime, Space.World);
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Translate(new Vector3(speed, 0, 0) * Time.deltaTime, Space.World);
        }

        if(Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.Translate(new Vector3(0, 0, speed)*Time.deltaTime,Space.World);
        }
        if(Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.Translate(new Vector3(0, 0, -speed) * Time.deltaTime, Space.World);
        }
        
    }
}
