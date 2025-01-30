using UnityEngine;
using System;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

namespace MainSpace
{

    // Categorize by aspect ratio
    public enum e_MediaAspectRatio
    {
        Undefined,
        Landscape,
        Portrait
    }

    [ExecuteAlways]
    public class MediaQuery : MonoBehaviour
    {
        [SerializeField] UIDocument m_Document;

        // Minimum aspect to be considered landscape
        [SerializeField] 
        public static float k_LandscapeMin = 1.2f;

        // Stores the current screen resolution
        Vector2 m_CurrentResolution;

        // Landscape, Portrait, or Undefined
        e_MediaAspectRatio m_CurrentAspectRatio;

        //Get function, read only 
        public Vector2 CurrentResolution => m_CurrentResolution;

        private void OnEnable()
        {
            Debug.Log("[MediaQuery]: OnEnable");

            if (m_Document == null) {
                Debug.Log("[MediaQuery]: Please assign UI Document");
                return;
            }

            VisualElement root = m_Document.rootVisualElement;

            if (root != null)
                root.RegisterCallback<GeometryChangedEvent>(OnGeometryChanged);

        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        void OnGeometryChanged(GeometryChangedEvent evt)
        {
            UpdateResolution();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public static e_MediaAspectRatio CalculateAspectRatio(Vector2 resolution)
        {
            if (Math.Abs(resolution.y) < float.Epsilon)
            {
                Debug.LogWarning("[MediaQuery] CalculateAspectRatio: Height is zero. Cannot calculate aspect ratio.");
                return e_MediaAspectRatio.Undefined;
            }

            float aspectRatio = resolution.x / resolution.y;

            if (aspectRatio >= k_LandscapeMin)
            {
                return e_MediaAspectRatio.Landscape;
            }
            else
            {
                return e_MediaAspectRatio.Portrait;
            }
        }

        // Force update resolution and aspect ratio
        public void UpdateResolution()
        {
            Vector2 newResolution = new Vector2(Screen.width, Screen.height);
            MediaQueryEvents.ResolutionUpdated?.Invoke(newResolution);
            e_MediaAspectRatio newAspectRatio = CalculateAspectRatio(newResolution);
            MediaQueryEvents.AspectRatioUpdated?.Invoke(newAspectRatio);
        }
    }

}
