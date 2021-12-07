using UnityEditor;

namespace Geekbrains
{
    public class MenuItems
    {
        [MenuItem("Geekbrains/Interactive Objects _i")]
        private static void MenuOption()
        {
            EditorWindow.GetWindow(typeof(InteractiveObjectWindow), false, "Geekbrains");
        }

        [MenuItem("Assets/Geekbrains/Interactive Objects")]
        private static void AssetsMenuOption()
        {
            EditorWindow.GetWindow(typeof(InteractiveObjectWindow), false, "Geekbrains");
        }

        [MenuItem("CONTEXT/GameController/Interactive Objects")]
        private static void ScriptMenuOption()
        {
            EditorWindow.GetWindow(typeof(InteractiveObjectWindow), false, "Geekbrains");
        }
    }
}