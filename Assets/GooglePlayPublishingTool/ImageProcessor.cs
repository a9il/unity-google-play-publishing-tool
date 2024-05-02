using System.IO;
using UnityEngine;

namespace AMG.GooglePlayPublishing
{
    public static class ImageProcessor
    {
        public static void GenerateAppIcon(Texture2D texture2D)
        {
            int width = Constant.IconWidthPx;
            int height = Constant.IconHeightPx;
            var renderTexture =
                new RenderTexture(width, height, Constant.IconPngBitDepth);
            RenderTexture.active = renderTexture;
            Graphics.Blit(texture2D, renderTexture);
            Texture2D result = new Texture2D(width, height,
                TextureFormat.RGBA32, false);
            var rect = new Rect(0, 0, width, height);
            result.ReadPixels(rect, 0, 0);
            result.Apply();
            var bytes = result.EncodeToPNG();
            if (!Directory.Exists(Constant.CreatedAssetDirectory))
            {
                Directory.CreateDirectory(Constant.CreatedAssetDirectory);
            }
            var filePath = Path.Combine(Constant.CreatedAssetDirectory,
                Constant.AppIconFileName);
            File.WriteAllBytes(filePath, bytes);
            string pathLink = Utility.GeneratePathLink(filePath);
            Debug.Log($"success create icon {pathLink}");
        }

        public static void CreateScreenshot(ScreenshotOrientation orientation)
        {
            var screenshotSize = Constant.ScreenshotSizePixel[orientation];
            int width = (int)screenshotSize.x;
            int height = (int)screenshotSize.y;
            int bitDepth = Constant.ScreenshotBitDepth;
            var fileName = Utility.GetScreenshotFilename();

            byte[] bytes = CreateScreenshot(width, height, bitDepth);
            if (!Directory.Exists(Constant.CreatedAssetDirectory))
            {
                Directory.CreateDirectory(Constant.CreatedAssetDirectory);
            }
            var filePath = Path.Combine(Constant.CreatedAssetDirectory, fileName);
            File.WriteAllBytes(filePath, bytes);
            string pathLink = Utility.GeneratePathLink(filePath);
            Debug.Log($"success create screenshot {pathLink}");
        }

        public static void CreateFeatureGraphic()
        {
            int width = Constant.FeatureGraphicWidthPx;
            int height = Constant.FeatureGraphicHeightPx;
            int bitDepth = Constant.ScreenshotBitDepth;
            var fileName = Constant.FeatureGraphicFilename;

            var bytes = CreateScreenshot(width, height, bitDepth);

            var filePath = Path.Combine(Constant.CreatedAssetDirectory, fileName);
            File.WriteAllBytes(filePath, bytes);
            string pathLink = Utility.GeneratePathLink(filePath);
            Debug.Log($"success create feature graphic {pathLink}");
        }

        private static byte[] CreateScreenshot(int width, int height,
             int bitDepth)
        {
            var camera = Camera.main;
            var renderTexture = new RenderTexture(width, height, bitDepth);
            camera.targetTexture = renderTexture;
            var screenshot = new Texture2D(width, height, TextureFormat.RGB24, false);
            camera.Render();
            RenderTexture.active = renderTexture;
            var rect = new Rect(0, 0, width, height);
            screenshot.ReadPixels(rect, 0, 0);
            camera.targetTexture = null;
            RenderTexture.active = null;
            var bytes = screenshot.EncodeToPNG();
            return bytes;
        }
    }
}