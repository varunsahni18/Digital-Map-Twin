using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.Map;
using Mapbox.Utils;
using Mapbox.Unity.Utilities;

public class SetPrefabPosition : MonoBehaviour
{
    // Start is called before the first frame update
    public AbstractMap map;
    public float _spawnScale = 100f;
    public List<int> countList;
    public string[] _locationStrings;
	private Vector2d[] _locations;	
    public List<GameObject> markerPrefabList;
	private List<GameObject> _spawnedObjects;
    void Start()
	{
        _locations = new Vector2d[_locationStrings.Length];
        _spawnedObjects = new List<GameObject>();
	}
 
    private void Update()
    {
        createPrefab();
        int count = _spawnedObjects.Count;
        for (int i = 0; i < count; i++)
        {
            var spawnedObject = _spawnedObjects[i];
            var location = _locations[i];
            spawnedObject.transform.localPosition = map.GeoToWorldPosition(location, true);
            spawnedObject.transform.localScale = new Vector3(_spawnScale, _spawnScale, _spawnScale);

        }
    }
    bool came = false;
    public void createPrefab() {
        
        if(map.AbsoluteZoom>4 && came==false) {
            for (int i = 0; i < _locationStrings.Length; i++)
            {
                for(int j=0; j< countList[i]; j++)
                {
                    var instance = Instantiate(markerPrefabList[i]);
                    var locationString = _locationStrings[i];
                    _locations[i] = Conversions.StringToLatLon(locationString);
                    
                    //instance.SetActive(false);
                    instance.transform.localPosition = map.GeoToWorldPosition(_locations[i], true);
                    instance.transform.localScale = new Vector3(_spawnScale, _spawnScale, _spawnScale);
                    _spawnedObjects.Add(instance);
                }
            }
            came=true;
        }
    }
}
