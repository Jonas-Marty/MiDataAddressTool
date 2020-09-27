using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace HitzgiAddressTool
{
	/// <summary>
	/// 
	/// </summary>
	/// <remarks>
	/// This Class is using the Json Serializer because the XmlSerializes is not out of the box capable of serializing Dictionaries...
	/// </remarks>
	public static class FileUtil
	{
	    private static readonly object _groupPrioritiesLock = new object();
	    private const string BaseFoldername = "HitzgiAddressTool";
		private const string CredentialsFileName = "Credentials.dat";
		private const string GroupPriorityFileName = "GroupPriorities.dat";
		private const string LogFileName = "HitzgiAdressToolLog.txt";

		public static string FullLogFilePath
		{
			get { return Path.Combine(MyDocumentsPath, BaseFoldername, LogFileName); }
		}

		private static string MyDocumentsPath
		{
			get { return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); }
		}

		public static void SaveLoginCredentials(LoginCredentials loginCredentials)
		{
			Serialize(loginCredentials, CredentialsFileName);
		}

		public static LoginCredentials LoadLoginCredentials()
		{
			return Deserialize<LoginCredentials>(CredentialsFileName);
		}

		/// <summary>
		/// Saves the grouppriorities, the key is the id of the group, the value is the priority.
		/// </summary>
		/// <param name="groupPriorities">The grouppriorities.</param>
		public static void SaveGroupPriorities(Dictionary<string, Tuple<int, bool>> groupPriorities)
		{
		    lock (_groupPrioritiesLock)
		    {
		        Serialize(groupPriorities, GroupPriorityFileName);
		    }
		}

	    public static Dictionary<string, Tuple<int, bool>> LoadGroupPriorities()
	    {
	        lock (_groupPrioritiesLock)
	        {
	            return Deserialize<Dictionary<string, Tuple<int, bool>>>(GroupPriorityFileName);
	        }
	    }

	    private static T Deserialize<T>(string fileName)
		{
			string fullPath = CreateFullPath(fileName);

			using (FileStream fileStream = new FileStream(fullPath, FileMode.Open))
			using (StreamReader streamReader = new StreamReader(fileStream))
			using (JsonReader jsonReader = new JsonTextReader(streamReader))
			{
				var jsonSerializer = JsonSerializer.Create();
				return jsonSerializer.Deserialize<T>(jsonReader);
			}
		}

		private static void Serialize<T>(T objectToSerialize, string filename, FileMode fileMode = FileMode.Create)
		{
			string fullPath = CreateFullPath(filename);

			CreatDirectoryIfNotExists(fullPath);

			using (FileStream fileStream = new FileStream(fullPath, fileMode))
			using (StreamWriter streamWriter = new StreamWriter(fileStream))
			{
				var jsonSerializer = JsonSerializer.Create();
				jsonSerializer.Serialize(streamWriter, objectToSerialize);
			}
		}

		private static string CreateFullPath(string secondPartOfFilePath)
		{
			return Path.Combine(MyDocumentsPath, BaseFoldername, secondPartOfFilePath);
		}

		private static void CreatDirectoryIfNotExists(string secondPartOfFilePath)
		{
			string directoryPath = Path.GetDirectoryName(secondPartOfFilePath);
			Debug.Assert(directoryPath != null, "Should never be null");
			Directory.CreateDirectory(directoryPath);
		}
	}
}