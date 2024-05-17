using System;
using UnityEngine;

public class ManaSystem : MonoBehaviour
{
    private CharacterStatHandler _statHandler;

    public float CurrentMP {  get; private set; }
    public event Action OnUsed;
    public event Action OnFilled;
    public float MaxMP => _statHandler.CurrentStat.MaxMP;

    private void Awake()
    {
        _statHandler = GetComponent<CharacterStatHandler>();
    }

    private void Start()
    {
        CurrentMP = MaxMP;
    }

    public void ChangeMP(float change)
    {
        CurrentMP += change;
        CurrentMP = Mathf.Clamp(CurrentMP, 0f, MaxMP);

        if(change <= 0f)
        {
            UseMana();
        }
        else
        {
            FillMana();
        }
    }

    private void FillMana()
    {
        OnFilled?.Invoke();
    }

    private void UseMana()
    {
        OnUsed?.Invoke();
    }
}
