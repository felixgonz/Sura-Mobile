using System;
using AFPCapital.Movil.Dependency;
using System.IO;
using Android;
using Android.Support.V4.Content;
using static Android.Manifest;

[assembly: Xamarin.Forms.Dependency(typeof(AFPCapital.Movil.Droid.Dependency.FileDependency))]
namespace AFPCapital.Movil.Droid.Dependency
{
    public class FileDependency:IFileDependency
    {
        public string BinaryWrite(string name, string base64)
        {
            const string permission = Manifest.Permission.WriteExternalStorage;
            var permisos=ContextCompat.CheckSelfPermission(Android.App.Application.Context, permission);
            //if ( == (int)Permission.WriteExternalStorage)
            //{
                string path = Path.Combine(Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDocuments).ToString(), name);
                byte[] bytes = Convert.FromBase64String(base64);
                using (System.IO.FileStream stream = new System.IO.FileStream(path, FileMode.CreateNew))
                {
                    using (System.IO.BinaryWriter writer = new System.IO.BinaryWriter(stream))
                    {
                        writer.Write(bytes, 0, bytes.Length);
                    }
                }
                return path;
            //}
            //else
            //{
            //    return string.Empty;
            //}
        }
    }
}