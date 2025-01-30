using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace MainSpace
{

    // Pairs a Panel Settings with a string 
    [Serializable]
    public struct ThemeSettings
    {
        public string theme;
        public PanelSettings panelSettings;
    }

    // This component changes the Panel Settings (from the Settings Screen or MediaQuery).

    [ExecuteAlways]
    public class ThemeManager : MonoBehaviour
    {
        [Tooltip("Reference to the UI Document to update for themes")]
        [SerializeField] UIDocument m_Document;
        [Tooltip("Theme is a string key, ThemeSettings, and Panel Settings")]
        [SerializeField] List<ThemeSettings> m_ThemeSettings;
        [SerializeField] bool m_Debug;

        string m_CurrentTheme;

        // Returns the corresponding index of a given theme
        int GetThemeIndex(string themeName)
        {
            if (string.IsNullOrEmpty(themeName))
                return -1;

            // Returns index from ThemeSettings (or -1 if not found)
            int index = m_ThemeSettings.FindIndex(x => x.theme == themeName);

            return index;
        }

        // Returns the corresponding PanelSettings for a given theme
        PanelSettings GetPanelSettings(string themeName)
        {
            int index = GetThemeIndex(themeName);

            if (index < 0)
            {
                Debug.LogWarning("[ThemeManager] GetPanelSettings: Invalid theme name" + themeName);
                return null;
            }
            return m_ThemeSettings[index].panelSettings;
        }        

        // Apply the theme's corresponding PanelSettings to the UI Document
        void SetPanelSettings(string theme)
        {
            PanelSettings panelSettings = GetPanelSettings(theme);

            if (panelSettings != null)
            {
                m_Document.panelSettings = panelSettings;
            }
            else if (m_Debug)
            {
                Debug.LogWarning("[ThemeManager] ApplyTheme: Found no matching PanelSettings for " + theme);
            }
        }        

        public static string GetSuffix(string input, string delimiter)
        {
            int lastIndex = input.LastIndexOf(delimiter);
            if (lastIndex == -1)
            {
                return string.Empty; // Delimiter not found, return an empty string
            }
            return input.Substring(lastIndex);
        }

        // Change the Theme Stylesheet in the PanelSettings asset
        public void ApplyTheme(string theme)
        {
            if (m_Document == null)
            {
                m_Document = FindFirstObjectByType<UIDocument>();
            }

            if (m_Document == null)
            {
                if (m_Debug)
                {
                    Debug.LogWarning("[ThemeManager] ApplyTheme: Unassigned UI Document.");
                }
                return;
            }

            SetPanelSettings(theme);

            m_CurrentTheme = theme;
        }

        // Re-apply Theme when switching between Portrait and Landscape
        void OnAspectRatioUpdated(e_MediaAspectRatio mediaAspectRatio)
        {
            // Save the suffix to Default, Christmas, or Halloween
            string suffix = GetSuffix(m_CurrentTheme, "--");

            // Add Portrait or Landscape as the basename
            string newThemeName = mediaAspectRatio.ToString() + suffix;

            ApplyTheme(newThemeName);

            if (m_Debug)
            {
                Debug.Log("[ThemeManager] OnAspectRatioUpdated: " + newThemeName);
            }
        }

        void OnEnable()
        {
            if (m_ThemeSettings.Count == 0)
            {
                Debug.LogWarning("[ThemeManager]: Add ThemeSettings to set themes");
                return;
            }
            
            // Theme changed via viewport sizes
            MediaQueryEvents.AspectRatioUpdated += OnAspectRatioUpdated;

            // Default to the first theme
            m_CurrentTheme = m_ThemeSettings[0].theme;
        }

        void OnDisable()
        {
            MediaQueryEvents.AspectRatioUpdated -= OnAspectRatioUpdated;
        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}