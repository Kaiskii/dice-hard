using UnityEngine.Events;
using UnityEngine;

[System.Serializable]
public class OnHealEvent : UnityEvent <int> { };

[CreateAssetMenu(fileName = "Heal", menuName = "DiceEfffects/HealEffectSO", order = 1)]
public class HealEffect : DiceEffect
{
    #region Serialized Fields
    [SerializeField] private OnHealEvent _onHealEvent;
    [SerializeField] private int incrementAmount = 1;
    #endregion

    public override void PerformAction()
    {
        base.PerformAction();
        _onHealEvent.Invoke(incrementAmount);
        Debug.Log($"Heal +{incrementAmount}");
    }
}
