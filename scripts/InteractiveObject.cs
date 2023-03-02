using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractiveObject : MonoBehaviour
{
    public abstract bool CanInteract { get; set; }
    public abstract void Interact();
    public abstract void Sabotage();
}

