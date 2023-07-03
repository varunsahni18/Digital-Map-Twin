using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.Map;
using Mapbox.Unity.Utilities;
using Mapbox.Utils;
public class rotateMap : MonoBehaviour
{
    [SerializeField]
			Transform _objectToRotate;

			[SerializeField]
			float _multiplier = 1f;

			Vector3 _startTouchPosition;
			public GameObject _map;

			void Update()
			{
				if (Input.GetMouseButtonDown(1))
				{
					_startTouchPosition = Input.mousePosition;
				}

				if (Input.GetMouseButton(1))
				{
					var dragDelta = Input.mousePosition - _startTouchPosition;
					var axis = new Vector3(0f, -dragDelta.x * _multiplier, 0f);
					_objectToRotate.RotateAround(_objectToRotate.position, axis, _multiplier);
					float currentZoom = _map.GetComponent<AbstractMap>().Options.locationOptions.zoom;
					Vector2d currentLocation = Conversions.StringToLatLon(_map.GetComponent<AbstractMap>().Options.locationOptions.latitudeLongitude);
					_map.GetComponent<AbstractMap>().UpdateMap(currentLocation, currentZoom);
				}
			}
}

