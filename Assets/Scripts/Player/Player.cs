using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerController Controller;
    public PlayerCondition Condition;
    public Equipment Equip;

    public ItemData ItemData;
    public Action AddItem;

    public Transform DropPosition;

    private void Awake()
    {
        CharacterManager.Instance.Player = this;
        Controller = GetComponent<PlayerController>();
        Condition = GetComponent<PlayerCondition>();
    }
}
