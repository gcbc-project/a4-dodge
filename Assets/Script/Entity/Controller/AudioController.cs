using UnityEngine;


public class AudioController : MonoBehaviour
{
    private readonly int _isAttack = Animator.StringToHash("isAttack");
    private PlayerController _playerController;
    private HealthSystem _healthSystem;   

    private AudioSource _audioSource;
    public AudioClip AttackClip;
    public AudioClip OnDashClip;
    public AudioClip OnHealthClip;
    public AudioClip OnDamageClip;
    public AudioClip OnDeathClip;


    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
        _healthSystem = GetComponent<HealthSystem>();
        _audioSource = GetComponent<AudioSource>();

        _playerController.OnAttackEvent += Attack;
        _playerController.OnDashEvent += Dash;
        _healthSystem.OnHealEvent += Heal;
        _healthSystem.OnDamageEvent += Damage;
        _healthSystem.OnDeathEvent += Death;
    }

    private void Attack(AttackSO attackData)
    {
        _audioSource.PlayOneShot(AttackClip);
    }

    private void Dash()
    {
        _audioSource.PlayOneShot(OnDashClip);
    }

    private void Heal()
    {
        _audioSource.PlayOneShot(OnHealthClip);
    }

    private void Damage()
    {
        _audioSource.PlayOneShot(OnDamageClip);
    }

    private void Death()
    {
        _audioSource.PlayOneShot(OnDeathClip);

    }
}
