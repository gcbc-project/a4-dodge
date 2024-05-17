using UnityEngine;

[CreateAssetMenu(fileName = "RangeAttackSO", menuName = "Scriptable Object/Attack/Range", order = 1)]

public class RangeAttackSO : AttackSO
{
    [Header("Range Attack Info")]
    public int ProjectileNum;
    public float ProjectileSize;
}
