using UnityEngine;

[CreateAssetMenu(fileName = "MeleeAttackSO", menuName = "Scriptable Object/Attack/Melee", order = 0)]

public class MeleAttackSO : AttackSO
{
    [Header("Melee Attack Info")]
    public float Reach;
}
