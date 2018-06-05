using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Stage2Script))]
public class Stage2TrapParameterEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var Stage2 = target as Stage2Script;
        //EditorGUILayout.LabelField("罠：" + Stage2Script.needleName);

        EditorGUILayout.LabelField("罠：" + Stage2Script.fallenNeedleName);
        Stage2.FallenNeedle_FallenVeloc = EditorGUILayout.FloatField("落ちる速度", Stage2.FallenNeedle_FallenVeloc);
        Stage2.FallenNeedle_To_Next_distance = EditorGUILayout.FloatField("次の針が落ちる間隔", Stage2.FallenNeedle_To_Next_distance);

        EditorGUILayout.LabelField("罠：" + Stage2Script.remoteFloorName);
        Stage2.RemoteFloor1_MaxBottomY = EditorGUILayout.FloatField("床1が止まる位置", Stage2.RemoteFloor1_MaxBottomY);
        Stage2.RemoteFloor2_MaxBottomY = EditorGUILayout.FloatField("床2が止まる位置", Stage2.RemoteFloor2_MaxBottomY);
        Stage2.RemoteFloor_FallenVeloc = EditorGUILayout.FloatField("落ちる速度", Stage2.RemoteFloor_FallenVeloc);

        EditorGUILayout.LabelField("罠：" + Stage2Script.stoneName);
        Stage2.Stone_FallenVeloc = EditorGUILayout.FloatField("落ちる速度", Stage2.Stone_FallenVeloc);
        Stage2.Stone_HitFloor_AddForce = EditorGUILayout.FloatField("床に落ちた瞬間に発生する力", Stage2.Stone_HitFloor_AddForce);
        
        //EditorGUILayout.LabelField("リアルタイム編集" + UIScript.parameter_ChangeEnable);
    }
}