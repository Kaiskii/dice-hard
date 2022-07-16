using UnityEngine.Events;
using UnityEngine;

[System.Serializable]
public class OnAttackEvent : UnityEvent <int> { };

[CreateAssetMenu(fileName = "Attack", menuName = "DiceEfffects/AttackEffectSO", order = 1)]
public class AttackEffect : DiceEffect
{
    #region Serialized Fields
    [SerializeField] private OnAttackEvent _onAttackEvent;
    [SerializeField] private int incrementAmount = 1;
    #endregion

    public override void PerformAction()
    {
        base.PerformAction();
        _onAttackEvent.Invoke(incrementAmount);
        Debug.Log($"Attack +{incrementAmount}");
    }
}
