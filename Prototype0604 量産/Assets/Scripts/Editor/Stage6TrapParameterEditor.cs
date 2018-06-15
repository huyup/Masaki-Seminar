//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEditor;

//[CustomEditor(typeof(Stage6Script))]
//public class Stage6TrapParameterEditor : Editor
//{

//    public override void OnInspectorGUI()
//    {
//        var Stage6 = target as Stage6Script;
//        //EditorGUILayout.LabelField("罠：" + Stage2Script.needleName);

//        EditorGUILayout.LabelField("装置：" + Stage6Script.mshinItoName);
//        Stage6.fallenVeloc = EditorGUILayout.FloatField("落ちる速度：", Stage6.fallenVeloc3);
//        Stage6.conflictForce = EditorGUILayout.FloatField("床が与える速度：", Stage6.conflictForce);

//        EditorGUILayout.LabelField("装置：" + Stage6Script.mshinItoName2);
//        Stage6.fallenVeloc2 = EditorGUILayout.FloatField("落ちる速度：", Stage6.fallenVeloc2);
//        Stage6.conflictForce2 = EditorGUILayout.FloatField("床が与える速度：", Stage6.conflictForce2);

//        EditorGUILayout.LabelField("装置：" + Stage6Script.mshinItoName3);
//        Stage6.fallenVeloc3 = EditorGUILayout.FloatField("落ちる速度：", Stage6.fallenVeloc3);
//        Stage6.conflictForce3 = EditorGUILayout.FloatField("床が与える速度：", Stage6.conflictForce3);

//        EditorGUILayout.LabelField("装置：" + Stage6Script.mshinItoName4);
//        Stage6.fallenVeloc4 = EditorGUILayout.FloatField("落ちる速度：", Stage6.fallenVeloc4);
//        Stage6.conflictForce4 = EditorGUILayout.FloatField("床が与える速度：", Stage6.conflictForce4);

//        EditorGUILayout.LabelField("装置：" + Stage6Script.mshinItoName5);
//        Stage6.fallenVeloc5 = EditorGUILayout.FloatField("落ちる速度：", Stage6.fallenVeloc5);
//        Stage6.conflictForce5 = EditorGUILayout.FloatField("床が与える速度：", Stage6.conflictForce5);

//        EditorGUILayout.LabelField("装置：" + Stage6Script.pressMachineName);
//        Stage6.fallenSpeed = EditorGUILayout.FloatField("落ちる速度", Stage6.fallenSpeed);
//        Stage6.raiseSpeed = EditorGUILayout.FloatField("上昇速度", Stage6.raiseSpeed);
//        Stage6.distanceToBottom = EditorGUILayout.FloatField("最低点", Stage6.distanceToBottom);
//        Stage6.distanceToTop = EditorGUILayout.FloatField("最高点", Stage6.distanceToTop);

//        EditorGUILayout.LabelField("装置：" + Stage6Script.pressMachineName2);
//        Stage6.fallenSpeed2 = EditorGUILayout.FloatField("落ちる速度", Stage6.fallenSpeed2);
//        Stage6.raiseSpeed2 = EditorGUILayout.FloatField("上昇速度", Stage6.raiseSpeed2);
//        Stage6.distanceToBottom2 = EditorGUILayout.FloatField("最低点", Stage6.distanceToBottom2);
//        Stage6.distanceToTop2 = EditorGUILayout.FloatField("最高点", Stage6.distanceToTop2);
//    }
//}
