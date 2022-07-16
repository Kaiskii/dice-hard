using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DiceEffectManager : Singleton<DiceEffectManager>
{
    #region Serialized Fields
    [SerializeField] private DiceEffect[] diceEffectLibrary;
    #endregion

    #region Private Fields
    private Dictionary <string, UnityEvent<int>> eventDictionary = new Dictionary<string, UnityEvent<int>>();
    #endregion

    public static void StartListening (string eventName, UnityAction<int> listener)
    {
        UnityEvent<int> thisEvent = null;
        if (Instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new UnityEvent<int>();
            thisEvent.AddListener(listener);
            Instance.eventDictionary.Add(eventName, thisEvent);
        }
    }

    public static void StopListening (string eventName, UnityAction<int> listener)
    {
        if (Instance == null) return;

        UnityEvent<int> thisEvent = null;
        if (Instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }

    public static void TriggerEvent (string eventName, int arg0)
    {
        UnityEvent<int> thisEvent = null;

        if (Instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.Invoke(arg0);
        }
        else
        {
            Debug.LogError($"{eventName} does not exist!");
        }
    }

    public DiceEffect[] GetDiceEffects => diceEffectLibrary;
}
