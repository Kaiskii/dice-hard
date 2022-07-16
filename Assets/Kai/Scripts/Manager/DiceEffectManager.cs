using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceEffectManager : Singleton<DiceEffectManager>
{
    #region Serialized Fields
    [SerializeField] private DiceEffect[] diceEffectLibrary;
    #endregion

    public DiceEffect[] GetDiceEffects => diceEffectLibrary;
}
