using UnityEngine;
using UnityEditor;
using System.Collections;

public class WindowEditor : EditorWindow
{
    private GameObject whatPrefab;
    private GameObject whatParent;

    private int numberSpawn = 1;
    private int MaxSpawndistance = 10;
    private string Name = "default";
    float minVal   = 1;
    float minLimit = 0;
    float maxVal   = 2;
    float maxLimit = 10;
    
    // Add menu item named "My Window" to the Window menu
    [MenuItem("Window/ObjectSpawnerWindow")]
    public static void ShowWindow()
    {
        //Show existing window instance. If one doesn't exist, make one.
        EditorWindow.GetWindow(typeof(WindowEditor));
    }
    
   void OnGUI()
    {
        GUILayout.Label ("What to spawn", EditorStyles.boldLabel);
        whatPrefab = (GameObject)EditorGUILayout.ObjectField ("what prefab", whatPrefab, typeof(object), true);
        whatParent = (GameObject)EditorGUILayout.ObjectField ("what Parent", whatParent, typeof(object), true);
        
        GUILayout.Label ("What to spawn", EditorStyles.boldLabel);
        Name = EditorGUILayout.TextField ("name of new object",Name);
        numberSpawn = EditorGUILayout.IntField ("number to spawn",numberSpawn);
        MaxSpawndistance = EditorGUILayout.IntField ("max spawn distance",MaxSpawndistance);
        
        EditorGUILayout.LabelField("Min Val:", minVal.ToString());
        EditorGUILayout.LabelField("Max Val:", maxVal.ToString());
        EditorGUILayout.MinMaxSlider(ref minVal, ref maxVal, minLimit, maxLimit);

        if (GUILayout.Button("Spawn " + numberSpawn + " object"))
        {               
            // code exec boutton
            
            float xParent = whatParent.transform.position.x;
            float yParent = whatParent.transform.position.y; 
            float zParent = whatParent.transform.position.z;

            GameObject whatPrefab2 = whatPrefab;
            
            for (int i = 0; i < numberSpawn; i++)
            {
                Vector3 random = new Vector3(Random.Range(xParent-MaxSpawndistance,xParent+MaxSpawndistance), 
                                             Random.Range(yParent-MaxSpawndistance,yParent+MaxSpawndistance), 
                                             Random.Range(zParent-MaxSpawndistance,zParent+MaxSpawndistance));

                Vector3 randomScale = new Vector3(Random.Range(minVal,maxVal),Random.Range(minVal,maxVal),Random.Range(minVal,maxVal));

                whatPrefab2.transform.localScale = randomScale;
                
                GameObject spawned = Instantiate(whatPrefab2,random,Quaternion.identity,whatParent.transform);
                      
            }
        }
    }
}

