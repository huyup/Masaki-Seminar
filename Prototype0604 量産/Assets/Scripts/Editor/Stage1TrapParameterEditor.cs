using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
    [CustomEditor(typeof(Stage1Script))]
public class Stage1TrapParameterEditor : Editor {

    public override void OnInspectorGUI()
    {
        var Stage1 = target as Stage1Script;
        //EditorGUILayout.LabelField("罠：" + Stage2Script.needleName);

        EditorGUILayout.LabelField("罠：" + Stage1Script.fallenTrapName);
        Stage1.fallenSpeed = EditorGUILayout.FloatField("落ちる速度", Stage1.fallenSpeed);
        Stage1.raiseSpeed = EditorGUILayout.FloatField("上昇速度", Stage1.raiseSpeed);
        Stage1.distanceToBottom = EditorGUILayout.FloatField("最低点", Stage1.distanceToBottom);
        Stage1.distanceToTop = EditorGUILayout.FloatField("最高点", Stage1.distanceToTop);

        EditorGUILayout.LabelField("罠：" + Stage1Script.fallenTrapName2);
        Stage1.fallenSpeed2 = EditorGUILayout.FloatField("落ちる速度", Stage1.fallenSpeed2);
        Stage1.raiseSpeed2 = EditorGUILayout.FloatField("上昇速度", Stage1.raiseSpeed2);
        Stage1.distanceToBottom2 = EditorGUILayout.FloatField("最低点", Stage1.distanceToBottom2);
        Stage1.distanceToTop2 = EditorGUILayout.FloatField("最高点", Stage1.distanceToTop2);

    }
}
