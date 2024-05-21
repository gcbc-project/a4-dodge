using UnityEngine;


public class AudioController : MonoBehaviour
{
    private readonly int _isAttack = Animator.StringToHash("isAttack");
    private PlayerController _playerController;

    private AudioSource _audioSource;
    private AudioClip _attackClip;
    //private AudioClip _onDamageClip; 

    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
        _audioSource = GetComponent<AudioSource>();

        _playerController.OnAttackEvent += Attack;        
    }

    private void Attack(AttackSO attackData)
    {
        _audioSource.PlayOneShot(_attackClip);
    }
}
