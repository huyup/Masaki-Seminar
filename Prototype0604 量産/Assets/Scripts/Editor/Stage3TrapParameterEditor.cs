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

        EditorGUILayout.LabelField("装置：" + Stage3Script.bedMachineName);
        Stage3.elasticity = EditorGUILayout.FloatField("弾力：", Stage3.elasticity);
        EditorGUILayout.LabelField("装置：" + Stage3Script.bedMachineName2);
        Stage3.elasticity2 = EditorGUILayout.FloatField("弾力：", Stage3.elasticity2);
        EditorGUILayout.LabelField("装置：" + Stage3Script.bedMachineName3);
        Stage3.elasticity3 = EditorGUILayout.FloatField("弾力：", Stage3.elasticity3);
        EditorGUILayout.LabelField("装置：" + Stage3Script.stoneFactoryName);
        Stage3.intervalOfCreate = EditorGUILayout.FloatField("間隔：", Stage3.intervalOfCreate);

        EditorGUILayout.LabelField("装置：" + Stage3Script.stoneFactoryName2);
        Stage3.intervalOfCreate2 = EditorGUILayout.FloatField("間隔：", Stage3.intervalOfCreate2);
    }
}
