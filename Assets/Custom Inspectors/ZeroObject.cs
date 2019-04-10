using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

[CustomEditor(typeof(ZeroObject))]

public class ZeroObject : Editor
{
    
    public Rigidbody myObject;
    private Vector3 zeroCoordinate = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        ZeroObject resetObject = (ZeroObject)target;

        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Zero Object"))
        {
            myObject.transform.position = zeroCoordinate;
            Debug.Log("Resetting the scene!");
        }

        GUILayout.EndHorizontal();
    }



}
