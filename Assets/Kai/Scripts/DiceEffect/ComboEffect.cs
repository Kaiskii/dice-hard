using UnityEngine;

[CreateAssetMenu(fileName = "Combo", menuName = "DiceEfffects/ComboSO", order = 1)]
public class ComboEffect : DiceEffect
{
    public override void PerformAction ()
    {
        base.PerformAction();
        DiceEffectManager.TriggerEvent("OnComboEvent", 0);
        Debug.Log($"Combo Buff Gained");
    }
}
