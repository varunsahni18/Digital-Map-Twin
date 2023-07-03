namespace Mapbox.Unity.Map
{
	using System;
	using Mapbox.Unity.MeshGeneration.Factories;
	public static class MapboxDefaultImagery
	{
		public static Style GetParameters(ImagerySourceType defaultImagery)
		{
			Style defaultStyle = new Style();
			//UnityEngine.Debug.Log("style is ................."+defaultImagery);

			switch (defaultImagery)
			{
				case ImagerySourceType.MMIRaster:
					defaultStyle = new Style
					{
						Id = "https://mt1.mapmyindia.com/advancedmaps/v1/",
						Name = "MMIRaster Tiles"
					};

					break;

				case ImagerySourceType.Custom:
					throw new Exception("Invalid type : Custom");
				case ImagerySourceType.None:
					throw new Exception("Invalid type : None");
				default:
					break;
			}

			return defaultStyle;
		}
	}
}
