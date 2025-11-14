using UnityEditor;
using UnityEngine;

namespace JacobHomanics.TrickedOutUI
{
    [CustomEditor(typeof(EnabledMinMaxComponent))]
    public class EnabledMinMaxComponentEditor : Editor
    {
        private SerializedProperty thresholdPercentProperty;
        private SerializedProperty thresholdTypeProperty;
        private SerializedProperty monoBehaviourProperty;

        private void OnEnable()
        {
            thresholdPercentProperty = serializedObject.FindProperty("thresholdPercent");
            thresholdTypeProperty = serializedObject.FindProperty("thresholdType");
            monoBehaviourProperty = serializedObject.FindProperty("monoBehaviour");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            // Display thresholdPercent as a percentage (0-100%)
            float percentValue = thresholdPercentProperty.floatValue;
            percentValue = EditorGUILayout.Slider("Threshold Percent", percentValue, 0f, 100f);
            thresholdPercentProperty.floatValue = percentValue;

            EditorGUILayout.PropertyField(thresholdTypeProperty);
            EditorGUILayout.PropertyField(monoBehaviourProperty);

            serializedObject.ApplyModifiedProperties();
        }
    }
}

