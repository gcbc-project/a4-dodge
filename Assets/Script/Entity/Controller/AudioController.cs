using UnityEngine;


public class AudioController : MonoBehaviour
{
    private readonly int _isAttack = Animator.StringToHash("isAttack");
    private PlayerController _playerController;

    private AudioSource _audioSource;
    public AudioClip _attackClip;
    public AudioClip _onDashClip; 

    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
        _audioSource = GetComponent<AudioSource>();

        _playerController.OnAttackEvent += Attack;
        _playerController.OnDashEvent += Dash;
        
    }

    private void Attack(AttackSO attackData)
    {
        _audioSource.PlayOneShot(_attackClip);
    }

    private void Dash()
    {
        _audioSource.PlayOneShot(_onDashClip);
    }

}
