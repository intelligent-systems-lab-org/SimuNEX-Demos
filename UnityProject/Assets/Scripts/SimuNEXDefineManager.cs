#if UNITY_EDITOR
using System.Linq;
using UnityEditor;
using UnityEditor.Compilation;

namespace SimuNEX.Examples
{
    [InitializeOnLoad]
    public static class SimuNEXDefineManager
    {
        private const string DefineSymbol = "SIMUNEX_INSTALLED";
        private const string PackageName = "com.intelsyslab.simunex";

        static SimuNEXDefineManager()
        {
            // Register the callback to run before compilation
            CompilationPipeline.compilationStarted += OnCompilationStarted;
            UpdateDefineSymbol(); // Also check and update immediately when the script loads
        }

        private static void OnCompilationStarted(object obj)
        {
            UpdateDefineSymbol();
        }

        private static void UpdateDefineSymbol()
        {
            // Check if the package is installed
            UnityEditor.PackageManager.PackageInfo packageInfo = UnityEditor.PackageManager.PackageInfo
                .FindForAssetPath("Packages/" + PackageName);

            // Get the current define symbols
            string definesString = PlayerSettings.GetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup);
            System.Collections.Generic.List<string> defines = definesString.Split(';').ToList();

            if (packageInfo != null)
            {
                // Add the define symbol if the package is installed
                if (!defines.Contains(DefineSymbol))
                {
                    defines.Add(DefineSymbol);
                    PlayerSettings.SetScriptingDefineSymbolsForGroup(
                        EditorUserBuildSettings.selectedBuildTargetGroup,
                        string.Join(";", defines.ToArray()));
                }
            }
            else
            {
                // Remove the define symbol if the package is not installed
                if (defines.Contains(DefineSymbol))
                {
                    defines.Remove(DefineSymbol);
                    PlayerSettings.SetScriptingDefineSymbolsForGroup(
                        EditorUserBuildSettings.selectedBuildTargetGroup,
                        string.Join(";", defines.ToArray()));
                }
            }
        }
    }
}
#endif
