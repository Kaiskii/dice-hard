using UnityEngine;

[CreateAssetMenu(fileName = "DoubleDamage", menuName = "DiceEfffects/DoubleDamageSO", order = 1)]
public class DoubleDamageEffect : DiceEffect
{
    public override void PerformAction ()
    {
        base.PerformAction();
        DiceEffectManager.TriggerEvent("OnDoubleDamageEvent", 0);
        Debug.Log($"DoubleDamage Buff Gained");
    }
}
