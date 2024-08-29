#if !SIMUNEX_INSTALLED
using UnityEditor;
using UnityEngine;

namespace SimuNEX.Examples
{
    [InitializeOnLoad]
    public static class SimuNEXChecker
    {
        static SimuNEXChecker()
        {
            LogMissingPackageWarning();
        }

        private static void LogMissingPackageWarning()
        {
            const string message = "SimuNEX package is not installed. " +
                "Please install the SimuNEX package using the Git URL to enable all demo features. " +
                "Go to Window > Package Manager, and add the package from git URL: " +
                "https://github.com/intelligent-systems-lab-org/SimuNEX.git?path=/UnityProject/Packages/com.intelsyslab.simunex#fs";

            Debug.LogWarning(message);
        }
    }
}
#endif
