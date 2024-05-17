using UnityEngine;

public class AttackSO : ScriptableObject
{
    [Header("Default Attack Info")]
    public float ATK;
    public float CoolTime;
    public LayerMask Target;
}
