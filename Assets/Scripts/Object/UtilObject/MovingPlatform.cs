using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour, IInteractable
{
    public UtilObjectData data;

    public string GetInteractPrompt()
    {
        string str = $"{data.displayName}\n{data.description}\n{data.utilization}";
        return str;
    }

    public void OnInteract()
    {
        // 출발 시키기
    }
}
