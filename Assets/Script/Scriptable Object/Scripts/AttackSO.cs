using UnityEngine;

[CreateAssetMenu(fileName = "AttackSO", menuName = "Scriptable Object/Attack/Default", order = 0)]
public class AttackSO : ScriptableObject
{
    [Header("Default Attack Info")]
    public float ATK;
    public float CoolTime;
    public LayerMask Target;
}
