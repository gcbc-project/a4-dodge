using UnityEngine;

public class AnimeController : MonoBehaviour
{
    private readonly int _isWalk = Animator.StringToHash("isWalk");
    private readonly int _isAttack = Animator.StringToHash("isAttack");
    private EntityController _controller;
    private Animator _animator;

    private void Awake()
    {
        _controller = GetComponent<EntityController>();
        _animator = GetComponent<Animator>();

        _controller.OnMoveEvent += Move;
        _controller.OnAttackEvent += Attack;
    }
    private void Move(Vector2 direction)
    {
        if (direction != null)
        {
            _animator.SetBool(_isWalk, direction.magnitude > 0);
        }
    }

    private void Attack(AttackSO attackData)
    {
        _animator.SetTrigger(_isAttack);
    }
}
