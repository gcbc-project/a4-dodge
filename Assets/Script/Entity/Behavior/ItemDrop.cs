using System;
using UnityEngine;

[Serializable]
public class ItemDrop
{
    public GameObject ItemPrefab;
    [Range(0f, 100f)]public float DropChance;
}
