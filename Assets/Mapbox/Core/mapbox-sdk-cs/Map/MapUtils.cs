//-----------------------------------------------------------------------
// <copyright file="MapUtils.cs" company="Mapbox">
//     Copyright (c) 2016 Mapbox. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Mapbox.Map
{
    using System;
    using Mapbox.Utils;
    using System.Text.RegularExpressions;   
    using System.IO; 

    /// <summary>
    /// Utilities for working with Map APIs.
    /// </summary>
    public static class MapUtils
	{
		
		/// <summary>
		/// Normalizes a static style URL.
		/// </summary>
		/// <returns>The static style URL.</returns>
		/// <param name="url">A url, either a Mapbox URI (mapbox://{username}/{styleid}) or a full url to a map.</param>
		//private MMIConfiguration _configuration;
		public static string NormalizeStaticStyleURL(string url)
		{
			bool isMapboxUrl = url.StartsWith("mapbox://", StringComparison.Ordinal);

			// Support full Mapbox URLs by returning here if a mapbox URL is not detected.
			if (!isMapboxUrl)
			{
				return url;
			}
                        //UnityEngine.Debug.Log("url is ##############"+url);
			string[] split = url.Split('/');
                        //UnityEngine.Debug.Log("split is ........"+split[3]);
			var user = split[3];
			var style = split[4];
			var draft = string.Empty;

			if (split.Length > 5)
			{
				draft = "/draft";
			}
                        //UnityEngine.Debug.Log("returing is..........."+(Constants.BaseAPI + "styles/v1/" + user + "/" + style + draft + "/tiles"));
			return Constants.BaseAPI + "styles/v1/" + user + "/" + style + draft + "/tiles";
		}

		/// <summary>
		/// Converts a TilesetId to a URL.
		/// </summary>
		/// <returns>The identifier to URL.</returns>
		/// <param name="id">The style id.</param>
		public static string TilesetIdToUrl(string id)
		{
			//string txt, txt1;
			string textFilePath, partialPath, textLicKey, folderPath;
                        //UnityEngine.Debug.Log("url DOWN ##############"+id);
                        Match http = Regex.Match(id,"^(http|https)://.*$");
			if(http.Success) {
                          //UnityEngine.Debug.Log("url DOWN ##############"+id);
		          Match dmt = Regex.Match(id,"dmt");
		       	  if(dmt.Success) {
			      return id;
			  }
			   //folderPath = "Assets/Resources/MMI";
			   //partialPath ="Assets/Resources/MMI/MMIConfiguration.txt"; 
			   //textFilePath = Path.GetFullPath(partialPath);
			   //textLicKey = File.ReadAllText(textFilePath);     
			  //new1 = MMIEditor.SetupMapEditor._configurationFile;
			  //UnityEngine.Debug.Log("UnityMapUtils.cs....."+"\""+new1+"\"");
		      //UnityEngine.Debug.Log($"curretn path is:\n {textFilePath}");	  
			  //return id +  textLicKey + "/still_map";
			  //return id"34pqmg2njthcdt4untjqh2y3k3g4tn8v" + "/still_map";
			  return id;
			}

			//string lic_key = "34pqmg2njthcdt4untjqh2y3k3g4tn8v";
			//return id + lic_key + "/still_map";
			
			else {
			  // TODO: Validate that id is a real id
			  const string MapBaseApi = Constants.BaseAPI + "v4/";
                          //UnityEngine.Debug.Log("final in tdy.........."+(MapBaseApi+id));
			  return MapBaseApi + id;
			}
		}
	}
}
