//using UnityEngine;
//using UnityEditor;

//[CustomEditor(typeof(Stage2Script))]
//public class Stage2TrapParameterEditor : Editor
//{
//    public override void OnInspectorGUI()
//    {
//        var Stage2 = target as Stage2Script;
//        //EditorGUILayout.LabelField("罠：" + Stage2Script.needleName);

//        EditorGUILayout.LabelField("罠：" + Stage2Script.fallenTrapName);
//        Stage2.fallenSpeed = EditorGUILayout.FloatField("落ちる速度", Stage2.fallenSpeed);
//        Stage2.raiseSpeed = EditorGUILayout.FloatField("上昇速度", Stage2.raiseSpeed);
//        Stage2.distanceToBottom = EditorGUILayout.FloatField("最低点", Stage2.distanceToBottom);
//        Stage2.distanceToTop = EditorGUILayout.FloatField("最高点", Stage2.distanceToTop);

//        EditorGUILayout.LabelField("罠：" + Stage2Script.fallenTrapName2);
//        Stage2.fallenSpeed2 = EditorGUILayout.FloatField("落ちる速度", Stage2.fallenSpeed2);
//        Stage2.raiseSpeed2 = EditorGUILayout.FloatField("上昇速度", Stage2.raiseSpeed2);
//        Stage2.distanceToBottom2 = EditorGUILayout.FloatField("最低点", Stage2.distanceToBottom2);
//        Stage2.distanceToTop2 = EditorGUILayout.FloatField("最高点", Stage2.distanceToTop2);

//        EditorGUILayout.LabelField("罠：" + Stage2Script.fallenTrapName3);
//        Stage2.fallenSpeed3 = EditorGUILayout.FloatField("落ちる速度", Stage2.fallenSpeed3);
//        Stage2.raiseSpeed3 = EditorGUILayout.FloatField("上昇速度", Stage2.raiseSpeed3);
//        Stage2.distanceToBottom3 = EditorGUILayout.FloatField("最低点", Stage2.distanceToBottom3);
//        Stage2.distanceToTop3 = EditorGUILayout.FloatField("最高点", Stage2.distanceToTop3);
//    }
//}