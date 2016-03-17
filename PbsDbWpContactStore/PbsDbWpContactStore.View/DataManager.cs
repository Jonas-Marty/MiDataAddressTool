using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using Windows.Storage;
using PbsDbAccess.Models;

namespace PbsDbWpContactStore.View
{
    public static class DataManager
    {
        public static Task SaveCredentialsAsync(UserCredentials userCredentials)
        {
            return SerializeAndSaveToFileAsync(FileNames.UserCredentialsFileName, userCredentials);
        }

        public static Task SavePeopleAsync(List<Person> people)
        {
            return SerializeAndSaveToFileAsync(FileNames.PeopleFileName, people);
        }

        public static Task SaveGroupsAsync(List<Group> groups)
        {
            return SerializeAndSaveToFileAsync(FileNames.GroupsFileName, groups);
        }

        public static Task<UserCredentials> LoadUserCredentialsAsync()
        {
            return LoadAndDeserealizeAsync<UserCredentials>(FileNames.UserCredentialsFileName);
        }

        public static Task<List<Person>> LoadPeopleAsync()
        {
            return LoadAndDeserealizeAsync<List<Person>>(FileNames.PeopleFileName);
        }

        public static Task<List<Group>> LoadGroupsAsync()
        {
            return LoadAndDeserealizeAsync<List<Group>>(FileNames.GroupsFileName);
        }

        private static async Task<T> LoadAndDeserealizeAsync<T>(string fileName) where T : class
        {
            using (var stream = await ApplicationData.Current.LocalFolder.OpenStreamForReadAsync(fileName))
            {
                return CreateSerializer<T>().ReadObject(stream) as T;
            }
        }

        private static async Task SerializeAndSaveToFileAsync<T>(string fileName, T objectToSave)
        {
            using (var stream = await ApplicationData.Current.LocalFolder.OpenStreamForWriteAsync(fileName, CreationCollisionOption.ReplaceExisting))
            {
                CreateSerializer<T>().WriteObject(stream, objectToSave);
            }
        }

        private static DataContractJsonSerializer CreateSerializer<T>()
        {
            return new DataContractJsonSerializer(typeof(T));
        }

        public static async Task<bool> DetermineIfSavedCredentialsAreExistingAsync()
        {
            return (await ApplicationData.Current.LocalFolder.GetFilesAsync())
                .Any(file => file.Name.Equals(FileNames.UserCredentialsFileName));
        }

        public static async Task<bool> DetermineIfSavedPeopleAreExistingAsync()
        {
            return (await ApplicationData.Current.LocalFolder.GetFilesAsync())
                .Any(file => file.Name.Equals(FileNames.PeopleFileName));
        }
    }
}
