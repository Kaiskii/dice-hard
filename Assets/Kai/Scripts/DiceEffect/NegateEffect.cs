using UnityEngine;

[CreateAssetMenu(fileName = "Negate", menuName = "DiceEfffects/NegateSO", order = 1)]
public class NegateEffect : DiceEffect
{
    public override void PerformAction ()
    {
        base.PerformAction();
        DiceEffectManager.TriggerEvent("OnNegateEvent", 0);
        Debug.Log($"Negate Buff Gained");
    }
}
