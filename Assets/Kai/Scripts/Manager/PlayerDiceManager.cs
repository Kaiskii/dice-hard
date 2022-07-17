using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class OnAttackEvent : UnityEvent <int> { };

public class PlayerDiceManager : Singleton<PlayerDiceManager>
{
    #region Public Fields
    public List<PlayerDice> _playerDices;
    #endregion

    private void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int rand = Random.Range(0, 5);
            PerformDiceAction(0, rand);
            Debug.Log($"Rolled {rand}");
        }
    }

    public void PerformDiceAction (int dice, int actionIndex)
    {
        DiceEffect diceEffect = _playerDices[dice]?.diceEffects[actionIndex];
        if (diceEffect != null)
            diceEffect.PerformAction();
    }

    #region Example Listening Usage Functions
    /*
    private void Start()
    {
        DiceEffectManager.StartListening("OnAttackEvent", OnAttackTestFunction);
        DiceEffectManager.StartListening("OnHealEvent", OnHealTestFunction);
    }

    private void OnAttackTestFunction (int amount)
    {
        Debug.Log($"Attack Increased by {amount}");
    }

    private void OnHealTestFunction (int amount)
    {
        Debug.Log($"Health Increased by {amount}");
    }
    */
    #endregion
}
