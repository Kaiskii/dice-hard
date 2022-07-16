using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceEffect : MonoBehaviour
{
    #region Serialized Fields
    [SerializeField] private float rarity;
    #endregion

    protected virtual void Start ()
    {
        Initialize();
    }

    protected virtual void Initialize () { }

    protected virtual void PerformAction () { }
}
