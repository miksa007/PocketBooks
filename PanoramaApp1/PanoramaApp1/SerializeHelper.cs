using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PanoramaApp1
{
    class SerializeHelper
    {
        public static void SaveData<T>(string fileName, T dataToSave)
        {
            using (IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication())
            {
                System.Diagnostics.Debug.WriteLine(" SaveData<T> seri save tapahtui");
                try
                {
                    if (store.FileExists(fileName))
                    {
                        store.DeleteFile(fileName);
                        System.Diagnostics.Debug.WriteLine(" SaveData<T> Tiedosto oli olemassa");
                    }
                    using (IsolatedStorageFileStream stream = store.OpenFile(fileName, System.IO.FileMode.Create, System.IO.FileAccess.Write))
                    {
                        var serializer = new DataContractSerializer(typeof(T));
                        serializer.WriteObject(stream, dataToSave);
                        System.Diagnostics.Debug.WriteLine(" SaveData<T> Kirjoitetaan dataa tiedostoon");
                    }
                }
                catch (InvalidDataContractException iExc)
                {
                    System.Diagnostics.Debug.WriteLine(" SaveData<T> invaliddatacontractexception");
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(" SaveData<T> Virhe 1");
                    //MessageBox.Show(e.Message);
                    return;
                }
            }
        }

        public static T ReadData<T>(string fileName)
        {
            System.Diagnostics.Debug.WriteLine("ReadData<T> seri read tapahtui");
            using (IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (store.FileExists(fileName))
                {
                    System.Diagnostics.Debug.WriteLine("ReadData<T> read tiedosto loytyi");
                    using (IsolatedStorageFileStream stream = store.OpenFile(fileName, FileMode.OpenOrCreate, FileAccess.Read))
                    {
                        try
                        {

                            var serializer = new DataContractSerializer(typeof(T));
                            System.Diagnostics.Debug.WriteLine("ReadData<T> tiedostoko muka löyty");
                            return (T)serializer.ReadObject(stream);
                        }
                        catch (InvalidDataContractException iExc)
                        {
                            System.Diagnostics.Debug.WriteLine(" ReadData<T> invaliddatacontractexception");
                        }
                        catch (Exception)
                        {
                            System.Diagnostics.Debug.WriteLine("ReadData<T> Virhe 2 - ei ollut tiedostooo");

                            return default(T);
                        }
                    }
                }
                return default(T);
            }
        }
    }
}
