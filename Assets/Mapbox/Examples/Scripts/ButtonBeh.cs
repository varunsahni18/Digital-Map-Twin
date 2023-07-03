namespace Mapbox.Examples
{
  using Mapbox.Unity.Map;
	using Mapbox.Unity.Utilities;
	using Mapbox.Utils;
	using UnityEngine;
	using System;


  public class ButtonBeh : MonoBehaviour
  {
    [SerializeField]
	  AbstractMap _abstractMap;

    public float latitude =  12.96991f;
    public float longitude = 77.59796f;
    public int zoom = 16;

    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {    
     
    }

    public  void flyToDestination() 
    {
      var latitudeLongitude = new Vector2d(latitude,longitude);
         
      try {
        _abstractMap.UpdateMap(latitudeLongitude,zoom);
      }
      catch (System.NullReferenceException e){
      //  Debug.Log("The error is "+e);
      }
    }


        public  void buttonupdateBangalore() 
    {
      var latitudeLongitude = new Vector2d(latitude,longitude);
         
      try {
        _abstractMap.UpdateMap(latitudeLongitude,zoom);
      }
      catch (System.NullReferenceException e){
        Debug.Log("The error is "+e);
      }
    }

    public  void buttonupdateDelhi() 
    {
      var latitudeLongitude = new Vector2d(latitude,longitude);
      try {
        _abstractMap.UpdateMap(latitudeLongitude,zoom);
      }
      catch (System.NullReferenceException e){
        Debug.Log("The error is "+e);
      }
    }

    public  void buttonupdateChennai() 
    {
      var latitudeLongitude = new Vector2d(latitude,longitude);
         
      try {
        _abstractMap.UpdateMap(latitudeLongitude,zoom);
      }
      catch (System.NullReferenceException e){
        Debug.Log("The error is "+e);
      }
    }
  }
}

