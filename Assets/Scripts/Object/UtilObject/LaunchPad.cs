using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPad : UtilObject
{
    [SerializeField] private float launchForce;

    public override void OnInteract()
    {
        UtilizeLaunchPad();
    }

    private void UtilizeLaunchPad()
    {
        Vector3 force = Vector3.up * launchForce;
        CharacterManager.Instance.Player.controller._rigidbody.AddForce(force, ForceMode.Impulse);
    }
}
