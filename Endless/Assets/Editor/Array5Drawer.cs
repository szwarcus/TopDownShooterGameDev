﻿using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomPropertyDrawer(typeof(MyArray5Layout))]
public class Array5Drawer : PropertyDrawer
{
    private int n = 5;
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.PrefixLabel(position, label);
        Rect newposition = position;
        newposition.y += 18f;
        SerializedProperty data = property.FindPropertyRelative("rows");
        for (int j = 0; j < n; j++)
        {
            SerializedProperty row = data.GetArrayElementAtIndex(j).FindPropertyRelative("row");
            newposition.height = 18f;
            if (row.arraySize != n)
                row.arraySize = n;
            newposition.width = position.width / n;
            for (int i = 0; i < n; i++)
            {
                EditorGUI.PropertyField(newposition, row.GetArrayElementAtIndex(i), GUIContent.none);
                newposition.x += newposition.width;
            }

            newposition.x = position.x;
            newposition.y += 18f;
        }
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return 18f * 8;
    }
}
