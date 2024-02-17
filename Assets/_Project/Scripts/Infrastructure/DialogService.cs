using System;
using System.IO;
using UnityEditor;

namespace CountersAnalysis
{
    public static class DialogService
    {
        public static string getFilePathWithExtension(string title, string directory, string extension)
        {
            string path = EditorUtility.OpenFilePanel(title, directory, extension);
            if (Path.GetExtension(path) != ("." + extension))
                throw new Exception("Wrong file extension");

            return path;
        }

        public static string getSavedFilePathWithExtension(string name, string title, string directory, string extension)
        {
            string path = EditorUtility.SaveFilePanel(title, directory, name, extension);
            if (Path.GetFileNameWithoutExtension(path) == "")
                throw new Exception("Wrong file name");

            if (Path.GetExtension(path) != ("." + extension))
                throw new Exception("Wrong file extension");

            return path;
        }

        public static void showMessage(string title, string message, string buttonText = "OK")
        {
            EditorUtility.DisplayDialog(title, message, buttonText);
        }
    }
}