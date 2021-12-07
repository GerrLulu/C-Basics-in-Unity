using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Geekbrains
{
    public class InteractiveObjectWindow : EditorWindow
    {
        public static InteractiveObject InteractiveObjectInstation;
        public string _nameObject;
        public float _xValue = 0.0f;
        public float _yValue = 0.0f;
        public float _zValue = 0.0f;
        public bool _groupEnabled;
        public Color _objectColor;
        public GameObject root;

        private bool _isPressButton;

        private void Awake()
        {
            root = new GameObject("Root");
        }

        private void OnGUI()
        {
            GUILayout.Label("Interactive Objects", EditorStyles.boldLabel);
            InteractiveObjectInstation = EditorGUILayout.ObjectField("������: ", InteractiveObjectInstation, typeof(InteractiveObject), true) as InteractiveObject;

            if (InteractiveObjectInstation != null)
            {
                _nameObject = InteractiveObjectInstation.name;
            }
            else if(InteractiveObjectInstation == null)
            {
                _nameObject = "�����";
            }

            _nameObject = EditorGUILayout.TextField("��� ������ :", _nameObject, EditorStyles.textArea);
            _xValue = EditorGUILayout.FloatField("X: ", _xValue);
            _yValue = EditorGUILayout.FloatField("Y: ", _yValue);
            _zValue = EditorGUILayout.FloatField("Z: ", _zValue);
            _groupEnabled = EditorGUILayout.BeginToggleGroup("��������� ����: ",
               _groupEnabled);
            _objectColor = EditorGUILayout.ColorField("�������� ����; ", _objectColor);
            EditorGUILayout.EndToggleGroup();
            var button = GUILayout.Button("������� �����", EditorStyles.miniButtonRight);
            if (button)
            {
                if (InteractiveObjectInstation)
                {
                    Vector3 spawnPoint = new Vector3(_xValue, _yValue, _zValue);
                    InteractiveObject temp = Instantiate(InteractiveObjectInstation, spawnPoint, Quaternion.identity);
                    SetObjectDirty(temp.gameObject);
                    temp.transform.parent = root.transform;
                    var tempRenderer = temp.GetComponent<Renderer>();
                    if(tempRenderer && !_groupEnabled)
                    {
                        tempRenderer.material.color = Random.ColorHSV();
                    }
                    else
                    {
                        tempRenderer.material.color = _objectColor;
                    }
                }
            }
        }

        public void SetObjectDirty(GameObject obj)
        {
            if (!Application.isPlaying)
            {
                EditorUtility.SetDirty(obj);
                EditorSceneManager.MarkSceneDirty(obj.scene);
            }
        }
    }
}
