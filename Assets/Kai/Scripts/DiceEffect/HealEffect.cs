using UnityEngine.Events;
using UnityEngine;

[System.Serializable]
public class OnHealEvent : UnityEvent <int> { };

public class HealEffect : DiceEffect
{
    #region Serialized Fields
    [SerializeField] private OnHealEvent _onHealEvent;
    [SerializeField] private int incrementAmount = 1;
    #endregion

    protected override void PerformAction()
    {
        base.PerformAction();
        _onHealEvent.Invoke(incrementAmount);
    }
}
