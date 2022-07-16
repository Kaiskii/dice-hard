using UnityEngine.Events;
using UnityEngine;

[CreateAssetMenu(fileName = "Heal", menuName = "DiceEfffects/HealEffectSO", order = 1)]
public class HealEffect : DiceEffect
{
    #region Serialized Fields
    [SerializeField] private int incrementAmount = 1;
    #endregion

    public override void PerformAction ()
    {
        base.PerformAction();
        DiceEffectManager.TriggerEvent("OnHealEvent", incrementAmount);
        Debug.Log($"Heal +{incrementAmount}");
    }
}
