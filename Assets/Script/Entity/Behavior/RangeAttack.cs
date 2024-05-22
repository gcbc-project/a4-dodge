using UnityEngine;


public class RangeAttack : Attack
{
    [SerializeField] private Transform _projectileSpawnPos;
    private AudioSource _audioSource;

    protected override void Awake()
    {
        base.Awake();
        _audioSource = GetComponent<AudioSource>();
    }

    protected override void ExecuteAttack(AttackSO attackData)
    {
        RangeAttackSO rangeAttackSO = attackData as RangeAttackSO;
        if (rangeAttackSO == null) return;

        float projectileAngle = rangeAttackSO.ProjectileAngle;
        int projectileNum = rangeAttackSO.ProjectileNum;

        float minAngle = -(projectileNum / 2f) * projectileAngle + 0.5f * rangeAttackSO.ProjectileAngle;
        for (int i = 0; i < projectileNum; i++)
        {
            float angle = minAngle + i * projectileAngle;
            _audioSource.Play();
            CreateProjectile(rangeAttackSO, angle);
        }
    }

    public void CreateProjectile(RangeAttackSO attackData, float angle)
    {
        GameObject obj = GameManager.Instance.ObjectPool.SpawnFromPool(attackData.ProjectileNameTag);
        obj.transform.position = _projectileSpawnPos.position;
        ProjectileController attackController = obj.GetComponent<ProjectileController>();
        attackController.Init(RotateVector2(_direction, angle), attackData);
    }

    private static Vector2 RotateVector2(Vector2 v, float angle)
    {
        return Quaternion.Euler(0f, 0f, angle) * v;
    }
}
