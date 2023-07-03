namespace Mapbox.Editor
{
	using System;
	using UnityEngine;
	using UnityEditor;
	using Mapbox.Unity.Map;

	public class VectorLayerPropertiesDrawer
	{
		private string objectId = "";
		/// <summary>
		/// Gets or sets a value to show or hide Vector section <see cref="T:Mapbox.Editor.MapManagerEditor"/>.
		/// </summary>
		/// <value><c>true</c> if show vector; otherwise, <c>false</c>.</value>
		bool ShowLocationPrefabs
		{
			get
			{
				return EditorPrefs.GetBool(objectId + "VectorLayerProperties_showLocationPrefabs");
			}
			set
			{
				EditorPrefs.SetBool(objectId + "VectorLayerProperties_showLocationPrefabs", value);
			}
		}

		/// <summary>
		/// Gets or sets a value to show or hide Vector section <see cref="T:Mapbox.Editor.MapManagerEditor"/>.
		/// </summary>
		/// <value><c>true</c> if show vector; otherwise, <c>false</c>.</value>
		bool ShowFeatures
		{
			get
			{
				return EditorPrefs.GetBool(objectId + "VectorLayerProperties_showFeatures");
			}
			set
			{
				EditorPrefs.SetBool(objectId + "VectorLayerProperties_showFeatures", value);
			}
		}

		private GUIContent _requiredTilesetIdGui = new GUIContent
		{
			text = "Required Tileset Id",
			tooltip = "For location prefabs to spawn the \"streets-v7\" tileset needs to be a part of the Vector data source"
		};

		FeaturesSubLayerPropertiesDrawer _vectorSublayerDrawer = new FeaturesSubLayerPropertiesDrawer();
		PointsOfInterestSubLayerPropertiesDrawer _poiSublayerDrawer = new PointsOfInterestSubLayerPropertiesDrawer();

		void ShowSepartor()
		{
			EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
			EditorGUILayout.Space();
		}

		public void DrawUI(SerializedProperty property)
		{
			objectId = property.serializedObject.targetObject.GetInstanceID().ToString();
			var layerSourceProperty = property.FindPropertyRelative("sourceOptions");
			var sourceTypeProperty = property.FindPropertyRelative("_sourceType");

			var names = sourceTypeProperty.enumNames;
			VectorSourceType sourceTypeValue = ((VectorSourceType) Enum.Parse(typeof(VectorSourceType), names[sourceTypeProperty.enumValueIndex]));
			//VectorSourceType sourceTypeValue = (VectorSourceType)sourceTypeProperty.enumValueIndex;
			string streets_v7 = MapboxDefaultVector.GetParameters(VectorSourceType.D3VStyle).Id;
			var layerSourceId = layerSourceProperty.FindPropertyRelative("layerSource.Id");
			//UnityEngine.Debug.Log("layerSourceId"+layerSourceId);
			string layerString = layerSourceId.stringValue;

			//Draw POI Section
			if (sourceTypeValue == VectorSourceType.None)
			{
				return;
			}

			//Draw Feature section.
			ShowFeatures = EditorGUILayout.Foldout(ShowFeatures, "FEATURES");
			if (ShowFeatures)
			{
				//UnityEngine.Debug.Log("showFeatures"+ShowFeatures);
				_vectorSublayerDrawer.DrawUI(property);
			}
		}

		public void PostProcessLayerProperties(SerializedProperty property)
		{

			var layerSourceProperty = property.FindPropertyRelative("sourceOptions");
			var sourceTypeProperty = property.FindPropertyRelative("_sourceType");
			VectorSourceType sourceTypeValue = (VectorSourceType)sourceTypeProperty.enumValueIndex;
			string streets_v7 = MapboxDefaultVector.GetParameters(VectorSourceType.D3VStyle).Id;
			var layerSourceId = layerSourceProperty.FindPropertyRelative("layerSource.Id");
			string layerString = layerSourceId.stringValue;

			
			if (ShowFeatures)
			{
				if (_vectorSublayerDrawer.isLayerAdded == true)
				{
					var subLayerArray = property.FindPropertyRelative("vectorSubLayers");
					var subLayer = subLayerArray.GetArrayElementAtIndex(subLayerArray.arraySize - 1);
					((VectorLayerProperties)EditorHelper.GetTargetObjectOfProperty(property)).OnSubLayerPropertyAdded(new VectorLayerUpdateArgs { property = EditorHelper.GetTargetObjectOfProperty(subLayer) as MapboxDataProperty });
					_vectorSublayerDrawer.isLayerAdded = false;
				}
			}

		}

	}
}
