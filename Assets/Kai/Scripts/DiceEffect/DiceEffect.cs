using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FaceModifier {
    Null,
    Explode,
}

[CreateAssetMenu(fileName = "Null", menuName = "DiceEfffects/NullSO", order = 1)]
public class DiceEffect : ScriptableObject
{
    #region Serialized Fields
    [SerializeField] private float rarity;
    #endregion

    #region Public Fields
    public FaceModifier faceModifier;
    #endregion

    protected virtual void Start ()
    {
        Initialize();
    }

    protected virtual void Initialize () { }

    public virtual void PerformAction () { }
}
