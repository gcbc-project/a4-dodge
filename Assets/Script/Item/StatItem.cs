using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatItem : MonoBehaviour, IItem
{
    // TODO : Stat, CharacterStatHandler Ŭ���� ���� �� �ּ� Ǯ��
    //[SerializeField] private Stat _effectStat;
    //private CharacterStatHandler _characterStatHandler;

    void IItem.OnTriggerEnter2D(Collider2D collision)
    {
        // �÷��̾� �±׿� �ε�����
        if (collision.CompareTag("Player"))
        {
            // �÷��̾� Stat ��������
            //_characterStatHandler = collision.GetComponent<CharacterStatHandler>();

            // ������ ȿ�� ����
            //_characterStatHandler._statModifiers.Add(_effectStat);
            //_characterStatHandler.UpdateStat();

            // ������ �ı�
            Destroy(gameObject);
        }
    }
}
