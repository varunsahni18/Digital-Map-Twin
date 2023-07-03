using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mapbox.Unity.Map;

public class cameraZoom : MonoBehaviour
{
    public GameObject _map;
    // public Slider slider;
    public Text textComponent;
    float counter=0.00f;
    
    // void Start(){
    //     slider.onValueChanged.AddListener(UpdateText);
    // }

    // void UpdateText(float val){
    //     // textComp.text = "Zoom: " + ((slider.value - 4)*10+100).ToString();
    //     // counter=0;
    //     textComponent.text= "Zoom: " + slider.value;
    //     counter=(val-100)/100;
    //     Debug.Log("updateText is called");
    //     _map.GetComponent<AbstractMap>().SetZoom(4+counter);
    // }

    void Update(){
        if(Input.GetAxis("Mouse ScrollWheel")>0){
            if(counter<15)
            {
                counter= counter + 0.2f;
                _map.GetComponent<AbstractMap>().SetZoom(4+counter);
                textComponent.text= "Zoom: " + (Mathf.RoundToInt(100 + counter*100)).ToString() + "%";
            }
         }   
        if(Input.GetAxis("Mouse ScrollWheel")<0){
            if(counter>0){
                counter= counter - 0.2f;
                _map.GetComponent<AbstractMap>().SetZoom(4+counter);
                textComponent.text= "Zoom: " + (Mathf.RoundToInt(100 + counter*100)).ToString() + "%";
            }
            
        }
    }
}
