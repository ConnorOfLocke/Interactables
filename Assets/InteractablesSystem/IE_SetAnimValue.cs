﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;

[CustomEditor(typeof(IE_SetAnimValue))]
public class IE_SetAnimValue_Editor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        IE_SetAnimValue.AnimValueType curType = (IE_SetAnimValue.AnimValueType)serializedObject.FindProperty("valueType").enumValueIndex;

        if (curType == IE_SetAnimValue.AnimValueType.Bool)
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("boolValue"));
        }
        else if (curType == IE_SetAnimValue.AnimValueType.Integer)
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("intValue"));
        }
        else if (curType == IE_SetAnimValue.AnimValueType.Float)
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("floatValue"));
        }

        serializedObject.ApplyModifiedProperties();
    }
}

#endif

public class IE_SetAnimValue : InteractableEffect
{
    [SerializeField]
    [Tooltip("Animator to set values to")]
    private Animator targetAnimator;

    [SerializeField]
    [Tooltip("Name of the animator property to change")]
    private string valueName;

    [SerializeField]
    [Tooltip("Data Type of the animator property to change")]
    private AnimValueType valueType;

    [HideInInspector]
    public bool boolValue;
    
    [HideInInspector]
    public int intValue;

    [HideInInspector]
    public float floatValue;

    public override void Fire()
    {
        if (targetAnimator != null)
        {
            switch (valueType)
            {
                case AnimValueType.Bool:
                    targetAnimator.SetBool(valueName, boolValue);
                    break;
                case AnimValueType.Integer:
                    targetAnimator.SetInteger(valueName, intValue);
                    break;
                case AnimValueType.Float:
                    targetAnimator.SetFloat(valueName, floatValue);
                    break;
            }
        }
        else
            Debug.LogWarning("[Interactable] [TriggerAnim] targetAnimator is null");
    }

    public enum AnimValueType
    {
        Bool,
        Integer,
        Float,
    };
}



