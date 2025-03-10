using UnityEngine;
using UnityEditor;

namespace Project.BTree.Editor
{
    [CustomEditor(typeof(CharacterThinker))]
    public class CharacterThinkerEditor : UnityEditor.Editor
    {
        private string _currentKey = string.Empty;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var thinker = (CharacterThinker)target;

            if (GUILayout.Button("Evaluate"))
            {
                Debug.Log(thinker.Evaluate());
            }

            if (GUILayout.Button("Validate"))
            {
                Debug.Log(thinker.Validate());
            }

            _currentKey = EditorGUILayout.TextField(_currentKey);
            if (GUILayout.Button("DebugMemory"))
            {
                Debug.Log(thinker.GetMemory(_currentKey));
            }
        }
    }
}
