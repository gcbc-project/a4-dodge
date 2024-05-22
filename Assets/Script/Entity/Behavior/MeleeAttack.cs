using System.Collections;
using UnityEngine;

public class MeleeAttack : Attack
{
    private Mesh mesh;
    private MeshFilter meshFilter;
    private MeshRenderer meshRenderer;
    private Material attackMaterial;
    [SerializeField] private GameObject _arm;
    private AudioSource _audioSource;

    protected override void Awake()
    {
        base.Awake();
        meshFilter = _arm.AddComponent<MeshFilter>();
        meshRenderer = _arm.AddComponent<MeshRenderer>();
        meshRenderer.enabled = false; // 처음에는 메쉬를 비활성화
        attackMaterial = new Material(Shader.Find("Sprites/Default"));
        attackMaterial.color = Color.red;
        Color color = attackMaterial.color;
        color.a = 0.2f;
        attackMaterial.color = color;
        meshRenderer.material = attackMaterial;
        meshRenderer.sortingOrder = 2;
        _audioSource = GetComponent<AudioSource>();
    }
    protected override void ExecuteAttack(AttackSO attackData)
    {
        MeleeAttackSO meleeAttackSO = attackData as MeleeAttackSO;
        Vector2 origin = transform.position;
        float halfAngle = meleeAttackSO.Angle * 0.5f;
        StartCoroutine(ShowAttackCone(meleeAttackSO));
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(origin, meleeAttackSO.Reach, meleeAttackSO.Target);
        foreach (Collider2D target in hitEnemies)
        {
            Vector2 targetOrigin = target.transform.position;
            Vector2 directionToTarget = (targetOrigin - origin).normalized;
            float angleToTarget = Vector2.Angle(_direction, directionToTarget);
            if (angleToTarget < halfAngle)
            {
                Hit(target, meleeAttackSO);
                continue;
            }
            RaycastHit2D hitMax = Physics2D.Raycast(origin, Quaternion.Euler(0, 0, halfAngle) * _direction, meleeAttackSO.Reach, meleeAttackSO.Target);
            RaycastHit2D hitMin = Physics2D.Raycast(origin, Quaternion.Euler(0, 0, -halfAngle) * _direction, meleeAttackSO.Reach, meleeAttackSO.Target);
            if (hitMax.collider != null || hitMin.collider != null)
            {
                Hit(target, meleeAttackSO);
            }
        }
        _audioSource.Play();
    }
    private void Hit(Collider2D target, MeleeAttackSO attackData)
    {
        HealthSystem healthSystem = target.gameObject.GetComponent<HealthSystem>();
        healthSystem.ChangeHP(-(attackData.ATK));
    }
    
    private IEnumerator ShowAttackCone(MeleeAttackSO meleeAttackSO)
    {
        CreateAttackConeMesh(meleeAttackSO);
        meshRenderer.enabled = true;
        yield return new WaitForSeconds(0.3f);
        meshRenderer.enabled = false;
    }
    
    private void CreateAttackConeMesh(MeleeAttackSO meleeAttackSO)
    {
        int segments = 20; // 곡선을 근사할 때 사용하는 변수
        float angleStep = meleeAttackSO.Angle / segments;
        float startAngle = -meleeAttackSO.Angle / 2;
        Vector3[] vertices = new Vector3[segments + 2];
        int[] triangles = new int[segments * 3];
        vertices[0] = Vector3.zero;
        for (int i = 0; i <= segments; i++)
        {
            float currentAngle = startAngle + angleStep * i;
            Vector3 direction = Quaternion.Euler(0, 0, currentAngle) * Vector3.right * meleeAttackSO.Reach;
            vertices[i + 1] = direction;
        }
        for (int i = 0; i < segments; i++)
        {
            triangles[i * 3] = 0;
            triangles[i * 3 + 1] = i + 1;
            triangles[i * 3 + 2] = i + 2;
        }
        mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
        meshFilter.mesh = mesh;
    }
}