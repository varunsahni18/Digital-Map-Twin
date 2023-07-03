using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class zoomValue : MonoBehaviour
{
    public Slider slider;
    public Text textComp;
    int counter =0;
    // void Awake() {
    //     slider = GetComponentInParent<Slider>();
    //     textComp = GetComponent<Text>();
    // }
    void Start(){
        slider.onValueChanged.AddListener(UpdateText);
    } 
    void UpdateText(float val){
        textComp.text = "Zoom: " + ((slider.value - 4)*10+100).ToString();
        counter=0;
    }
    void Update() {
        if(Input.GetAxis("Mouse ScrollWheel")>0){
                counter+=1;
                textComp.text = "Zoom: " + ((slider.value - 4)*10+100+(int)Mathf.Floor((counter/22))).ToString();            
        }   
        if(Input.GetAxis("Mouse ScrollWheel")<0){
            slider.value-=1;
            counter-=1;
            textComp.text = "Zoom: " + ((slider.value - 4)*10+100+(int)Mathf.Floor((counter/22))).ToString();
        }
        
    }
}
