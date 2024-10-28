using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilObject : MonoBehaviour, IInteractable
{
    public UtilObjectData data;

    public virtual string GetInteractPrompt()
    {
        string str = $"{data.displayName}\n{data.description}\n{data.utilization}";
        return str;
    }

    public virtual void OnInteract()
    {

    }
}
