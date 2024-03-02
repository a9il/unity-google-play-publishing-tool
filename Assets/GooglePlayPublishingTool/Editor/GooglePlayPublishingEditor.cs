using System;
using UnityEditor;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UIElements;

namespace AMG.GooglePlayPublishing
{
    public class GooglePlayPublishingEditor : EditorWindow
    {
        private ObjectField iconTexture;

        [MenuItem("Tools/Google Play Publishing Tool")]
        private static void ShowEditorWindow()
        {
            GooglePlayPublishingEditor window =
                GetWindow<GooglePlayPublishingEditor>();
            window.titleContent =
                new GUIContent("Google Play Publishing Tools");

        }

        private void CreateGUI()
        {
            // Each editor window contains a root VisualElement object
            VisualElement root = rootVisualElement;

            Label label = new Label("Upon publishing to google play store"
            + "\nwe need some screenshots and icon from the game");
            root.Add(label);

            iconTexture = new ObjectField("Drag icon here")
            {
                objectType = typeof(Texture2D)
            };
            root.Add(iconTexture);

            CreateButton("Generate Icon", OnGenerateIconButtonClicked);
            CreateButton("Create Feature Graphic From Camera.main",
                OnCreateFeatureGraphicClicked);
            CreateButton("Create Portrait Screenshot From Camera.main",
                OnCreatePortraitScreenshotClicked);
            CreateButton("Createa Landscape Screenshot From Camera.main",
                OnCreateLandscapeScreenshotClicked);
        }

        private void OnCreateFeatureGraphicClicked()
        {
            ImageProcessor.CreateFeatureGraphic();
        }

        private void OnCreateLandscapeScreenshotClicked()
        {
            ImageProcessor.CreateScreenshot(ScreenshotOrientation.Landscape);
        }

        private void CreateButton(string label, Action clickAction)
        {
            Button button = new()
            {
                text = label
            };
            button.clicked += clickAction;
            rootVisualElement.Add(button);
        }

        private void OnCreatePortraitScreenshotClicked()
        {
            ImageProcessor.CreateScreenshot(ScreenshotOrientation.Portrait);
        }

        private void OnGenerateIconButtonClicked()
        {
            Texture2D icon = (Texture2D)iconTexture.value;
            if (icon == null)
            {
                Debug.LogError($"unassigned icon, please assign it first");
            }
            else
            {
                ImageProcessor.GenerateAppIcon(icon);
            }
        }
    }
}
