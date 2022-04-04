using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Newtonsoft.Json;
public class GenerateJsonWindow : EditorWindow
{
    Vector2 scrollPosition;
    public GameObject[] listOfObjects;
    InteractionPoints interactionPointData;
    [MenuItem("Interaction Points/GenerateJSON")]
    static void init()
    {
        GenerateJsonWindow window = (GenerateJsonWindow)EditorWindow.GetWindow(typeof(GenerateJsonWindow));
        window.maxSize = new Vector2(1000, 350);
        window.Show();
    }
    private void OnGUI()
    {

        ScriptableObject scriptableobject = this;
        SerializedObject serialObject = new SerializedObject(scriptableobject);
        SerializedProperty serialProperty = serialObject.FindProperty("listOfObjects");
        scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);
        EditorGUILayout.PropertyField(serialProperty,true);
        serialObject.ApplyModifiedProperties();
        if(GUILayout.Button("Generate", GUILayout.MinWidth(250), GUILayout.MaxWidth(1000), GUILayout.MinHeight(50), GUILayout.MaxHeight(50)))
        {
            GenerateJSON();
        }
        EditorGUILayout.EndScrollView();
    }

    private void GenerateJSON()
    {
        if (listOfObjects.Length > 0)
        {
            interactionPointData = new InteractionPoints();
            List<InteractionObject> interactionPoints = new List<InteractionObject>();
            foreach (GameObject go in listOfObjects)
            {
                if (go != null)
                {
                    GUID uniqueID = GUID.Generate();
                    InteractionObject interactionPoint = new InteractionObject();
                    interactionPoint.objectID = uniqueID.ToString();
                    interactionPoint.objectLabel = go.transform.name;
                    interactionPoint.objectTransform.position.Add(go.transform.position.x);
                    interactionPoint.objectTransform.position.Add(go.transform.position.y);
                    interactionPoint.objectTransform.position.Add(go.transform.position.z);
                    interactionPoint.objectTransform.rotation.Add(go.transform.eulerAngles.x);
                    interactionPoint.objectTransform.rotation.Add(go.transform.eulerAngles.y);
                    interactionPoint.objectTransform.rotation.Add(go.transform.eulerAngles.z);
                    interactionPoint.objectTransform.scale.Add(go.transform.localScale.x);
                    interactionPoint.objectTransform.scale.Add(go.transform.localScale.y);
                    interactionPoint.objectTransform.scale.Add(go.transform.localScale.z);
                    interactionPoints.Add(interactionPoint);

                }
                else
                {
                    Debug.LogWarning("Assign value");
                }
            }
            interactionPointData.InteractionObjects = interactionPoints;
            string fileContent=JsonConvert.SerializeObject(interactionPointData,Formatting.Indented);
            System.IO.File.WriteAllText(Application.dataPath + "/test.json" , fileContent);
        }
    }
}
