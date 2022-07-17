using UnityEngine;

[CreateAssetMenu(fileName = "Lifesteal", menuName = "DiceEfffects/LifestealSO", order = 1)]
public class LifestealEffect : DiceEffect
{
    public override void PerformAction ()
    {
        base.PerformAction();
        DiceEffectManager.TriggerEvent("OnLifestealEvent", 0);
        Debug.Log($"Lifesteal Buff Gained");
    }
}
