using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mapbox.Unity.Map;
using Mapbox.Unity.Utilities;
using Mapbox.Utils;


public class naviagateTo : MonoBehaviour
{
    public InputField latitudeInput;
    public InputField longitudeInput;
    public GameObject _map;
    private Vector2d startLocation;
    private Vector2d endLocation;
    public float timeToFly = 12.0f;
    public float timeToZoomOut = 0.9f;

    public void OnSubmit(){
        Debug.Log(latitudeInput.text + ", " + longitudeInput.text);
        double _endLatitude = Convert.ToDouble(latitudeInput.text);
        double _endLongitude = Convert.ToDouble(longitudeInput.text);
        endLocation = new Vector2d(_endLatitude, _endLongitude);
        startLocation = Conversions.StringToLatLon(_map.GetComponent<AbstractMap>().Options.locationOptions.latitudeLongitude);
        float startzoom = _map.GetComponent<AbstractMap>().Options.locationOptions.zoom;
        StartCoroutine(moveMap(startLocation, endLocation, startzoom, timeToFly));
    }
    IEnumerator moveMap(Vector2d startposition, Vector2d endposition, float currentZoom, float overTime1){
        float startTime = Time.time;
        float overTime0 = (Mathf.Abs(currentZoom - 4.01f))*timeToZoomOut;
        while(Time.time < startTime +overTime0)
        {
            _map.GetComponent<AbstractMap>().UpdateMap(startposition, (currentZoom + (4.01f - currentZoom)*(Time.time - startTime)/overTime0));
            yield return null;
        }
        _map.GetComponent<AbstractMap>().SetZoom(4.01f);
        startTime = Time.time;
        while(Time.time < startTime + overTime1)
        {
            _map.GetComponent<AbstractMap>().UpdateMap(Vector2d.Lerp(startposition, endposition, (Time.time - startTime)/overTime1), (4.01f + ((currentZoom - 4.01f)*((Time.time - startTime)/overTime1))));
            yield return null;
        }
        _map.GetComponent<AbstractMap>().UpdateMap(endposition, currentZoom);
    }
    
}