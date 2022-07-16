using UnityEngine.Events;
using UnityEngine;

[System.Serializable]
public class OnAttackEvent : UnityEvent <int> { };

public class AttackEffect : DiceEffect
{
    #region Serialized Fields
    [SerializeField] private OnAttackEvent _onAttackEvent;
    [SerializeField] private int incrementAmount = 1;
    #endregion

    protected override void PerformAction()
    {
        base.PerformAction();
        _onAttackEvent.Invoke(incrementAmount);
    }
}
