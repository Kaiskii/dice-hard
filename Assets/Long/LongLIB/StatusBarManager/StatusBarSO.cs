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
        if(currValue+val>maxValue){
            currValue = maxValue;
        } else {
            currValue = currValue+val;
        }
    }
}

