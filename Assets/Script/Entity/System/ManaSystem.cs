using System;
using UnityEngine;

public class ManaSystem : MonoBehaviour
{
    public float CurrentMP {  get; private set; }
    public event Action OnUsed;
    public event Action OnFilled;
    public event Action<float> OnMPChanged;
    public float MaxMP => _statHandler.CurrentStat.MaxMP;

    private CharacterStatHandler _statHandler;
    
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
            Use();
        }
        else
        {
            Fill();
        }
        OnMPChanged?.Invoke(CurrentMP);
    }

    private void Fill()
    {
        OnFilled?.Invoke();
    }

    private void Use()
    {
        OnUsed?.Invoke();
    }
}
