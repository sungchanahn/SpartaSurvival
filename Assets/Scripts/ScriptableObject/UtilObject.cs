using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UtilObject", menuName = "New UtilObject")]
public class UtilObjectData : ScriptableObject
{
    [Header("Info")]
    public string displayName;
    public string description;
}
