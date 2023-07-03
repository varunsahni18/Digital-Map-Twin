namespace Mapbox.Unity.Map
{
	using System.IO;
	using Mapbox.Unity.Map;
	using UnityEngine;
	using System.Text;
	using Mapbox.Json;

	public class TileStatsFetcher
	{
		private static TileStatsFetcher _instance;
		private string _filePath = "Assets/Mapbox/Unity/DataContainers/streets-v7-stats.json";
		public static TileStatsFetcher Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new TileStatsFetcher();
				}
				return _instance;
			}
		}
		/// <summary>
		/// Gets the tile stats json for the supplied source Id.
		/// </summary>
		/// <returns>A prepopulated <see cref=" TileStats"/> instance.</returns>
		/// <param name="sourceId">Source Id of the Mapbox Tileset.</param>
		public TileStats GetTileStats(VectorSourceType sourceType)
		{
			TileStats stats = null;
			switch (sourceType)
			{
				case VectorSourceType.D3VStyle:
					using (Stream stream = new FileStream(_filePath, FileMode.Open))
					{
						using (StreamReader reader = new StreamReader(stream))
						{
							stats = JsonConvert.DeserializeObject<TileStats>(reader.ReadToEnd());
						}
					}
					break;
				default:
					break;
			}
							UnityEngine.Debug.Log("stat  value is..."+stats);
			return stats;
		}
	}
}
