using UnityEngine;

[CreateAssetMenu(fileName = "Multiply", menuName = "DiceEfffects/MultiplySO", order = 1)]
public class MultiplyEffect : DiceEffect
{
    #region Serialized Fields
    [SerializeField] private int incrementAmount = 1;
    #endregion

    public override void PerformAction ()
    {
        base.PerformAction();
        DiceEffectManager.TriggerEvent("OnMultiplyEvent", incrementAmount);
        Debug.Log($"Multiply Buff Gained");
    }
}
