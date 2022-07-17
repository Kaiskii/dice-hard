using UnityEngine;

/**
A example scriptableObject for the Resource Index.
*/

[System.Serializable]
[CreateAssetMenu(fileName = "NewStatusBar", menuName = "ScriptableObjects/Status Bar", order = 1)]
public class StatusBarSO : ScriptableObject
{
    [SerializeField]
    private string barName;
    [SerializeField]
    private float maxValue;
    [SerializeField]
    private float currValue;

    public string GetBarName(){
        return barName;
    }

    public float GetBarMaxValue(){
        return maxValue;
    }

    public float GetBarCurrentValue(){
        return currValue;
    }

    public void SetBarMaxValue(float val){
        maxValue = val;
    }

    public void SetBarCurrentValue(float val){
        currValue = val;
    }

    public void AddBarValue(float val){
        currValue += val;
        if(currValue > maxValue) currValue = maxValue;
        if(currValue < 0) currValue = 0;
    }

    public void AddBarMaxValue(float val){
        maxValue += val;
    }
}

