using System.Collections.Generic;
using UnityEngine;

namespace AMG.GooglePlayPublishing
{
    public class Constant
    {
        public const int IconWidthPx = 512;
        public const int IconHeightPx = IconWidthPx;

        public const int FeatureGraphicWidthPx = 1024;
        public const int FeatureGraphicHeightPx = 500;

        public static readonly Dictionary<ScreenshotOrientation, Vector2>
            ScreenshotSizePixel =
            new Dictionary<ScreenshotOrientation, Vector2>()
            {
                {ScreenshotOrientation.Portrait, new Vector2(1080, 1920)},
                {ScreenshotOrientation.Landscape, new Vector2(1920, 1080)},
            };
        public readonly int[] PhoneLandscapeAspecRatio =
            new int[] { 16, 9 };
        public readonly int[] PhonePortraitAspectRatio =
            new int[] { 9, 16 };
        private static int[] phonePixelSize = new int[2];
        public static int[] GetPixelSize(int[] phoneAspectRatio)
        {
            for (int i = 0; i < phoneAspectRatio.Length; i++)
            {
                phonePixelSize[i] =
                    phoneAspectRatio[i] * AspectRatioUnitPx;
            }
            return phonePixelSize;
        }
        /// <summary>
        /// for promotion the screenshot widht/height at least 1080
        /// 9 * 120 = 1080 
        /// </summary>
        private const int AspectRatioUnitPx = 120;
        /// <summary>
        /// https://developer.android.com/distribute/google-play/resources/icon-design-specifications
        /// </summary>
        public const int IconPngBitDepth = 32;
        public const int ScreenshotBitDepth = 24;

        public const string CreatedAssetDirectory = "CreatedAssets";
        public const string AppIconFileName = "app-icon.png";
        public const string FeatureGraphicFilename = "feature-graphic.png";

    }
}