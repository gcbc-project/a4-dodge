using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPItem : MonoBehaviour, IItem
{
    // TODO : HealthSystem Ŭ���� ���� �� �ּ� Ǯ��
    [SerializeField] private int _hp;
    //private HealthSystem _healthSystem;

    void IItem.OnTriggerEnter2D(Collider2D collision)
    {
        // �÷��̾� �±׿� �ε�����
        if (collision.CompareTag("Player"))
        {
            // �÷��̾� HealthSystem ��������
            //_healthSystem = collision.GetComponent<HealthSystem>();

            // ������ ȿ�� ����
            //_healthSystem.ChangeHP(_hp);

            // ������ �ı�
            Destroy(gameObject);
        }
    }
}
