using System;
using UnityEngine;

namespace MainSpace
{
    /// <summary>
    /// Public static delegates associated with changing screen resolution and aspect ratio.
    /// This is used to Caterpillarrm any components listening for landscape/portrait switching.
    ///
    /// Note: these are "events" in the conceptual sense and not the strict C# sense.
    /// </summary>
    public class MediaQueryEvents
    {
        // Raised when the screen dimension changes
        public static Action<Vector2> ResolutionUpdated;

        public static Action<e_MediaAspectRatio> AspectRatioUpdated;

        public static Action CameraResized;

        public static Action SafeAreaApplied;
    }
}
