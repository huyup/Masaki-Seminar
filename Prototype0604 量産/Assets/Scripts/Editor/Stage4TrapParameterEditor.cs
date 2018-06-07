using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(Stage4Script))]
public class Stage4TrapParameterEditor : Editor
{

    public override void OnInspectorGUI()
    {
        var Stage4 = target as Stage4Script;
        //EditorGUILayout.LabelField("罠：" + Stage2Script.needleName);

        EditorGUILayout.LabelField("装置：" + Stage4Script.bedMachineName);
        Stage4.elasticity= EditorGUILayout.FloatField("弾力：",Stage4.elasticity);
        EditorGUILayout.LabelField("装置：" + Stage4Script.bedMachineName2);
        Stage4.elasticity2 = EditorGUILayout.FloatField("弾力：", Stage4.elasticity2);
        EditorGUILayout.LabelField("装置：" + Stage4Script.bedMachineName3);
        Stage4.elasticity3 = EditorGUILayout.FloatField("弾力：", Stage4.elasticity3);
        EditorGUILayout.LabelField("装置：" + Stage4Script.stoneFactoryName);
        Stage4.intervalOfCreate = EditorGUILayout.FloatField("間隔：", Stage4.intervalOfCreate);

        EditorGUILayout.LabelField("装置：" + Stage4Script.stoneFactoryName2);
        Stage4.intervalOfCreate2 = EditorGUILayout.FloatField("間隔：", Stage4.intervalOfCreate2);
    }
}
