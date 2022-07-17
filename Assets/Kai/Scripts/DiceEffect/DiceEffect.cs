using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceEffect : ScriptableObject
{
    #region Serialized Fields
    [SerializeField] private float rarity;
    #endregion

    protected virtual void Start ()
    {
        Initialize();
    }

    protected virtual void Initialize () { }

    public virtual void PerformAction () { }
}
