using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDiceManager : Singleton<PlayerDiceManager>
{
    #region Public Fields
    public List<PlayerDice> _playerDices;
    #endregion

    private void Update()
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
}
