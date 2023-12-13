using System;
using System.IO;
using UnityEditor;

namespace CountersAnalysis
{
    public static class DialogService
    {
        public static string choseFile(string title = "Chose file", string directory = "", string targetExtension = "")
        {
            string path = EditorUtility.OpenFilePanel(title, directory, targetExtension);
            if (targetExtension == "")
                return path;
            
            if (Path.GetExtension(path) == ("." + targetExtension))
                return path;
            
            throw new Exception("Wrong file path or extension");
        }

        public static string saveFile(string name = "", string title = "Enter File Name", string directory = "", string targetExtension = "")
        {
            string path = EditorUtility.SaveFilePanel(title, directory, name, targetExtension);
            if (Path.GetFileNameWithoutExtension(path) != "")
                return path;

            throw new Exception("Wrong file name or extension");
        }

        public static void showMessage(string title, string message, string buttonText = "OK")
        {
            EditorUtility.DisplayDialog(title, message, buttonText);
        }
    }
}