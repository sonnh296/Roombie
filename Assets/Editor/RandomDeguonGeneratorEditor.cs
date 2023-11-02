using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AbstractDeguonGenerator), true)]
public class RandomDeguonGeneratorEditor : Editor
{
    AbstractDeguonGenerator generator;

    private void Awake() {
        generator = (AbstractDeguonGenerator)target;
    }

    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        if(GUILayout.Button("Create Dungeon")) {
            generator.GenerateDeguon();
        }
    }
}
