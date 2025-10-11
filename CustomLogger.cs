using UnityEngine;

namespace Utilities
{
    public static class DLogger
    {
#if !RELEASE
#endif
        // ReSharper disable Unity.PerformanceAnalysis
        public static void Log(string message, string tag = "DLogger", string color = "#FFFFFF")
        {
#if !RELEASE
            Debug.LogFormat("<color={2}>[{0}]</color> {1}", tag, message, color);
#endif
        }

        // ReSharper disable Unity.PerformanceAnalysis
        public static void LogWarning(string message, string tag = "DLogger", string color = "#FFFFFF")
        {
#if !RELEASE
            Debug.LogWarningFormat("<color={2}>[{0}]</color> {1}", tag, message, color);
#endif
        }

        // ReSharper disable Unity.PerformanceAnalysis
        public static void LogError(string message, string tag = "DLogger", string color = "#FFFFFF")
        {
#if !RELEASE
            Debug.LogErrorFormat("<color={2}>[{0}]</color> {1}", tag, message, color);
#endif
        }
    }

}