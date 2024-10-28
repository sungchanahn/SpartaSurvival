using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPad : MonoBehaviour, IInteractable
{
    public UtilObjectData data;
    [SerializeField] private float launchForce;

    public string GetInteractPrompt()
    {
        string str = $"{data.displayName}\n{data.description}\n{data.utilization}";
        return str;
    }

    public void OnInteract()
    {
        UtilizeLaunchPad();
    }

    private void UtilizeLaunchPad()
    {
        Vector3 force = Vector3.up * launchForce;
        CharacterManager.Instance.Player.Controller._rigidbody.AddForce(force, ForceMode.Impulse);
    }
}
