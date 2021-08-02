﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IE_FireOtherInteractable : InteractableEffect
{
    [SerializeField]
    [Tooltip("Interactable to force to fire (Will happen synchronously)")]
    BaseInteractable interactable;

    public override void Fire()
    {
        if (interactable != null)
            interactable.Fire();
        else
            Debug.LogWarning("[Interactable] [FireOtherInteractable] interactable is null");
    }


}
