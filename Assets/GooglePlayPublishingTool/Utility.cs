using System;
using System.IO;
using UnityEngine;

namespace AMG.GooglePlayPublishing
{
    public class Utility
    {
        private static string GetCreatedAssetDirectoryUrl()
        {
            var projectPath = Directory.GetParent(Application.dataPath);
            var directoryFullPath = Path.Combine(projectPath.ToString(),
                Constant.CreatedAssetDirectory);
            Uri uri = new Uri(directoryFullPath);
            var directoryUrl = uri.AbsoluteUri;
            return directoryUrl;
        }

        public static string GeneratePathLink(string filePath)
        {
            var directoryUrl = GetCreatedAssetDirectoryUrl();
            var fullPath = Path.Combine(directoryUrl, filePath);
            var result = $"<a href=\"{directoryUrl} \" "
                + $"target=\"_blank\">{fullPath}</a>";
            return result;
        }

        public static string GetScreenshotFilename()
        {
            return "screenshot_" +
                DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + ".png";
        }
    }
}