using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPItem : MonoBehaviour, IItem
{
    [SerializeField] private int Mp;
    private ManaSystem _manaSystem;

    void IItem.OnTriggerEnter2D(Collider2D collision)
    {
        // �÷��̾� �±׿� �ε�����
        if (collision.CompareTag("Player"))
        {
            // �÷��̾� ManaSystem ��������
            _manaSystem = collision.GetComponent<ManaSystem>();
            // ������ ȿ�� ����
            _manaSystem.ChangeMP(Mp);
            // ������ �ı�
            Destroy(gameObject);
        }
    }
}
