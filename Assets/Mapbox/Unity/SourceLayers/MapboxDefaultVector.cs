namespace Mapbox.Unity.Map
{
	using System;

	public static class MapboxDefaultVector
	{
		public static Style GetParameters(VectorSourceType defaultElevation)
		{
			Style defaultStyle = new Style();
			switch (defaultElevation)
			{
				case VectorSourceType.D3VStyle:
					defaultStyle = new Style
					{
						Id = "http://dmt.vidteq.com/bangalore/tilecache/BANG_GIRGITI/tiles/0.13.0",
						//Id = "http://dmt.vidteq.com/bangalore/tilecache/BANG_GIRGITI/styles/0.3.0",
						Name = "DMT/D3V Style"
					};

					break;

				case VectorSourceType.Custom:
					throw new Exception("Invalid type : Custom");
				default:
					break;
			}

			return defaultStyle;
		}
	}
}
