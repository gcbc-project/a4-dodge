using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPItem : MonoBehaviour, IItem
{
    // TODO : ManaSystem Ŭ���� ���� �� �ּ� Ǯ��
    [SerializeField] private int _mp;
    //private ManaSystem _manaSystem;

    void IItem.OnTriggerEnter2D(Collider2D collision)
    {
        // �÷��̾� �±׿� �ε�����
        if (collision.CompareTag("Player"))
        {
            // �÷��̾� ManaSystem ��������
            //_manaSystem = collision.GetComponent<ManaSystem>();

            // ������ ȿ�� ����
            //_manaSystem.ChangeMP(_mp);

            // ������ �ı�
            Destroy(gameObject);
        }
    }
}
