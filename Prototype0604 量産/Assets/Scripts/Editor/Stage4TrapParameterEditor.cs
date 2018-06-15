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
        EditorGUILayout.LabelField("装置：" + Stage4Script.pressMachineName);

        Stage4.distanceToLeft = EditorGUILayout.FloatField("左のスタート位置：", Stage4.distanceToLeft);
        Stage4.distanceToRight = EditorGUILayout.FloatField("右のスタート位置：", Stage4.distanceToRight);
        Stage4.leftSpeed= EditorGUILayout.FloatField("左の速度：", Stage4.leftSpeed);
        Stage4.rightSpeed = EditorGUILayout.FloatField("右の速度：", Stage4.rightSpeed);

        EditorGUILayout.LabelField("装置：" + Stage4Script.pressMachineName2);
        Stage4.distanceToLeft2 = EditorGUILayout.FloatField("左のスタート位置：", Stage4.distanceToLeft2);
        Stage4.distanceToRight2 = EditorGUILayout.FloatField("右のスタート位置：", Stage4.distanceToRight2);
        Stage4.leftSpeed2 = EditorGUILayout.FloatField("左の速度：", Stage4.leftSpeed2);
        Stage4.rightSpeed2 = EditorGUILayout.FloatField("右の速度：", Stage4.rightSpeed2);
    }
}
