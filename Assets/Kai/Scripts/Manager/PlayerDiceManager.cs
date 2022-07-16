using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDiceManager : Singleton<PlayerDiceManager>
{
    #region Public Fields
    public List<PlayerDice> _playerDices = new List<PlayerDice>();
    #endregion

    private void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _playerDices[0].diceEffects[0].faceModifier = FaceModifier.Explode;
            // Rolling
            for (int i = 0; i < _playerDices.Count; i += 1)
            {
                int rand = Random.Range(0, 5);
                Debug.Log($"Rolled {rand}");
                AddDiceActionToStack(i, rand);
            }
            // Finish Rolling

            // Perform Action
            for (int i = 0; i < _playerDices.Count; i += 1)
            {
                PopAllAction(i);
                _playerDices[i].Reset();
            }
            // Finish Performing Action
        }
    }

    /// <summary>
    /// Add the corresponding dice action retrieved from index to the Queue Stack
    /// </summary>
    /// <param name="diceIndex"></param>
    /// <param name="actionIndex"></param>
    public void AddDiceActionToStack (int diceIndex, int actionIndex)
    {
        DiceEffect diceEffect = _playerDices[diceIndex]?.diceEffects[actionIndex];

        if (diceEffect != null)
        {
            Queue<DiceEffect> dEQ = _playerDices[diceIndex].diceEffectQueue;
            dEQ.Enqueue(diceEffect);
            HandleFaceModifier(diceEffect.faceModifier, diceIndex);
        }

    }

    /// <summary>
    /// Performs the Dice Effect
    /// </summary>
    /// <param name="diceEffect"></param>
    /// <param name="diceIndex"></param>
    public void PerformDiceAction (DiceEffect diceEffect, int diceIndex)
    {
        if (diceEffect != null)
            diceEffect.PerformAction();
    }

    /// <summary>
    /// Retrieves the Dice Effect from the Player Dice List and performs it
    /// </summary>
    /// <param name="diceIndex"></param>
    /// <param name="actionIndex"></param>
    public void PerformDiceAction (int diceIndex, int actionIndex)
    {
        DiceEffect diceEffect = _playerDices[diceIndex]?.diceEffects[actionIndex];

        if (diceEffect != null)
            diceEffect.PerformAction();
    }

    /// <summary>
    /// Performs all action from the player dice queue
    /// </summary>
    /// <param name="diceIndex"></param>
    public void PopAllAction (int diceIndex)
    {
        Queue<DiceEffect> dEQ = _playerDices[diceIndex].diceEffectQueue;

        foreach (DiceEffect currEffect in dEQ)
        {
            PerformDiceAction(currEffect, diceIndex);
        }
    }

    /// <summary>
    /// Handles face modifiers on dice
    /// </summary>
    /// <param name="fm"></param>
    /// <param name="diceIndex"></param>
    private void HandleFaceModifier (FaceModifier fm, int diceIndex)
    {
        switch (fm)
        {
            case FaceModifier.Null:
                return;
            case FaceModifier.Explode:
                DiceEffectManager.TriggerEvent("OnExplodeEvent", diceIndex);
                break;
        }
    }

    /// <summary>
    /// Example of how to setup listeners
    /// </summary>
    #region Example Listening Usage Functions
    private void Start()
    {
        DiceEffectManager.StartListening("OnAttackEvent", OnAttackTestFunction);
        DiceEffectManager.StartListening("OnHealEvent", OnHealTestFunction);
        DiceEffectManager.StartListening("OnExplodeEvent", OnExplodeTestFunction);
    }

    private void OnAttackTestFunction (int amount)
    {
        Debug.Log($"Attack Increased by {amount}");
    }

    private void OnHealTestFunction (int amount)
    {
        Debug.Log($"Health Increased by {amount}");
    }

    private void OnExplodeTestFunction (int diceIndex)
    {
        int rand = Random.Range(0, 5);
        AddDiceActionToStack(diceIndex, rand);
        Debug.Log($"Explode - Rolled {rand}");
    }
    #endregion
}
