using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Prize))]
public class PrizeEditor : Editor
{
 
    SerializedProperty type;
    SerializedProperty elementType;
    SerializedProperty goldPrize;
    SerializedProperty profitPercent;
    SerializedProperty defencePercent;
    SerializedProperty luckPercent;
    SerializedProperty Sprite;


    private void OnEnable()
     {
        // ��������� ������ �� ������, ������� ������������ ���� ���������
        type = serializedObject.FindProperty("_Type");
        elementType = serializedObject.FindProperty("_ElementType");
        goldPrize = serializedObject.FindProperty("goldPrize");
        profitPercent = serializedObject.FindProperty("profitPercent");
        defencePercent = serializedObject.FindProperty("defencePercent");
        luckPercent = serializedObject.FindProperty("luckPercent");
        Sprite = serializedObject.FindProperty("sprite");

    }

    // ��������� � ����������
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(type);
        EditorGUILayout.PropertyField(elementType);
      
        EditorGUILayout.Space();

        // ���� ���� ������� �����, �� ���������� ������ ���� � ��������
        if ((type.enumValueIndex == (int)Type.gold_1)|| (type.enumValueIndex == (int)Type.gold_2) || (type.enumValueIndex == (int)Type.gold_3) )
        {
            EditorGUILayout.PropertyField(goldPrize);

        }
        // ����� ���������� ���� ��� �������� ��� ������ ���������� ��������
        else if (type.enumValueIndex == (int)Type.item_sword_1 || type.enumValueIndex == (int)Type.item_sword_2 || type.enumValueIndex == (int)Type.item_sword_3)
        {
            EditorGUILayout.PropertyField(profitPercent);
        }
        else if (type.enumValueIndex == (int)Type.item_shield_1 || type.enumValueIndex == (int)Type.item_shield_2 || type.enumValueIndex == (int)Type.item_shield_3)
        {
            EditorGUILayout.PropertyField(defencePercent);
        }
        else if (type.enumValueIndex == (int)Type.item_amulet_1 || type.enumValueIndex == (int)Type.item_amulet_2 || type.enumValueIndex == (int)Type.item_amulet_3)
        {
            EditorGUILayout.PropertyField(luckPercent);
        }
        EditorGUILayout.PropertyField(Sprite);
        // ��������� - ��������� �� ��������� � ����������
        serializedObject.ApplyModifiedProperties();
    }
}
