using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(Stage3Script))]
public class Stage3TrapParameterEditor : Editor
{

    public override void OnInspectorGUI()
    {
        var Stage3 = target as Stage3Script;
        //EditorGUILayout.LabelField("罠：" + Stage2Script.needleName);

        EditorGUILayout.LabelField("罠：" + Stage3Script.fallenTrapName);
        Stage3.fallenSpeed = EditorGUILayout.FloatField("落ちる速度", Stage3.fallenSpeed);
        Stage3.raiseSpeed = EditorGUILayout.FloatField("上昇速度", Stage3.raiseSpeed);
        Stage3.distanceToBottom = EditorGUILayout.FloatField("最低点", Stage3.distanceToBottom);
        Stage3.distanceToTop = EditorGUILayout.FloatField("最高点", Stage3.distanceToTop);

        EditorGUILayout.LabelField("罠：" + Stage3Script.fallenTrapName2);
        Stage3.fallenSpeed2 = EditorGUILayout.FloatField("落ちる速度", Stage3.fallenSpeed2);
        Stage3.raiseSpeed2 = EditorGUILayout.FloatField("上昇速度", Stage3.raiseSpeed2);
        Stage3.distanceToBottom2 = EditorGUILayout.FloatField("最低点", Stage3.distanceToBottom2);
        Stage3.distanceToTop2 = EditorGUILayout.FloatField("最高点", Stage3.distanceToTop2);

        EditorGUILayout.LabelField("罠：" + Stage3Script.fallenTrapName3);
        Stage3.fallenSpeed3 = EditorGUILayout.FloatField("落ちる速度", Stage3.fallenSpeed3);
        Stage3.raiseSpeed3 = EditorGUILayout.FloatField("上昇速度", Stage3.raiseSpeed3);
        Stage3.distanceToBottom3 = EditorGUILayout.FloatField("最低点", Stage3.distanceToBottom3);
        Stage3.distanceToTop3 = EditorGUILayout.FloatField("最高点", Stage3.distanceToTop3);
    }
}
