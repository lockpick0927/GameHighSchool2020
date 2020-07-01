using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Test : EditorWindow
{
    [MenuItem("Window/Test")]



    static void Init()
    {
        Test window = (Test)EditorWindow.GetWindow(typeof(Test));
        window.Show();
    }

    void OnGUI()
    {
        Handles.color = Color.red;
        Handles.DrawRectangle(0, new Vector3(200, 200), Quaternion.identity, 100);
        Handles.color = Color.black;
        Handles.DrawSolidDisc(new Vector3(150, 100, 0), Vector3.forward, 50);
        Handles.DrawSolidDisc(new Vector3(250, 100, 0), Vector3.forward, 50);
        Handles.color = Color.white;
        Handles.DrawSolidDisc(new Vector3(200, 200, 0), Vector3.forward, 100);
    }
}