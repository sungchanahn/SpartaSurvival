using System;
using UnityEngine;

public enum ItemType
{
    Equipable,
    Consumable,
    Resource
}

public enum ConsumableType
{
    Health,
    Hunger,
    Buff
}

[Serializable]
public class ItemdataConsumable
{
    public ConsumableType type;
    public float value;
}

[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public string displayName;
    public string description;
    public ItemType type;
    public Sprite icon;
    public GameObject dropPrefab;

    [Header("Stacking")]
    public bool canStack;
    public int maxStackAmount;

    [Header("Consumable")]
    public ItemdataConsumable[] consumables;

    [Header("Equip")]
    public GameObject equipPrefab;
}
