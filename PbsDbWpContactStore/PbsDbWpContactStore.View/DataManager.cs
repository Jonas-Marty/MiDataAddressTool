using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using Windows.Storage;
using PbsDbAccess.Models;

namespace PbsDbWpContactStore.View
{
	public static class DataManager
	{
		public static Task SaveCredentials(UserCredentials userCredentials)
		{
			return SerializeAndSaveToFile(FileNames.ContactsFileName, userCredentials);
		}

		public static Task<UserCredentials> LoadUserCredentials()
		{
			return LoadAndDeserealize<UserCredentials>(FileNames.UserCredentialsFileName);
		}

		public static Task SaveContacts(List<Person> people)
		{
			return SerializeAndSaveToFile(FileNames.ContactsFileName, people);
		}

		public static Task<List<Person>> LoadContacts()
		{
			return LoadAndDeserealize<List<Person>>(FileNames.ContactsFileName);
		}

		private static async Task<T> LoadAndDeserealize<T>(string fileName) where T : class
		{
			StorageFile credentialsFile =
				   await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
			DataContractJsonSerializer serializer = GetSerializer<T>();

			var credentialFileStream = await credentialsFile.OpenReadAsync();

			var readObject = serializer.ReadObject(credentialFileStream.AsStream());

			return readObject as T;
		}

		private static async Task SerializeAndSaveToFile<T>(string fileName, T objectToSave)
		{
			StorageFile contactsFile =
				await ApplicationData.Current.LocalFolder.CreateFileAsync(fileName,
					CreationCollisionOption.ReplaceExisting);

			var transactedWrite = await contactsFile.OpenTransactedWriteAsync();

			DataContractJsonSerializer serializer = GetSerializer<T>();

			serializer.WriteObject(transactedWrite.Stream.AsStream(), objectToSave);
		}

		private static DataContractJsonSerializer GetSerializer<T>()
		{
			return new DataContractJsonSerializer(typeof(T));
		}
	}
}
