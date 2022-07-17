using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerDice", menuName = "PlayerDice", order = 1)]
public class PlayerDice : ScriptableObject
{
    public List<DiceEffect> diceEffects = new List<DiceEffect>();
    public Queue<DiceEffect> diceEffectQueue = new Queue<DiceEffect>();

    public void Reset()
    {
        this.diceEffectQueue.Clear();
    }
}
