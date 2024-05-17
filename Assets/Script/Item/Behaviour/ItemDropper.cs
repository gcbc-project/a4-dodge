using System.Collections.Generic;
using UnityEngine;

public class ItemDropper : MonoBehaviour
{
    [Header("아이템이 안나오는 확률은 프리팹을 비워두고 DropChance만 사용")]
    [SerializeField] private List<ItemDrop> _items = new List<ItemDrop> { new ItemDrop() };
    private HealthSystem _healthSystem;

    private void Awake()
    {
        _healthSystem = GetComponent<HealthSystem>();
        _healthSystem.OnDeathEvent += Drop;
    }

    public void Drop()
    {
        float totalWeight = 0f;
        foreach (var item in _items)
        {
            totalWeight += item.DropChance;
        }

        float randomNumber = Random.Range(0f, totalWeight);
        float weightSum = 0f;

        foreach (var item in _items)
        {
            weightSum += item.DropChance;
            if (randomNumber <= weightSum && item.ItemPrefab != null)
            {
                Instantiate(item.ItemPrefab, transform.position, Quaternion.identity);
                break;
            }
        }
    }
}
