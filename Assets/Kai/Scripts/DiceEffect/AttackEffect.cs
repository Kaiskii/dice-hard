using UnityEngine;

[CreateAssetMenu(fileName = "Attack", menuName = "DiceEfffects/AttackEffectSO", order = 1)]
public class AttackEffect : DiceEffect
{
    #region Serialized Fields
    [SerializeField] private int incrementAmount = 1;
    #endregion

    public override void PerformAction ()
    {
        base.PerformAction();
        DiceEffectManager.TriggerEvent("OnAttackEvent", incrementAmount);
        Debug.Log($"Attack +{incrementAmount}");
    }
}
