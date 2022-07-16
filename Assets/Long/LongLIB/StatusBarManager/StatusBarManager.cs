using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusBarManager : Singleton<StatusBarManager>
{
    List<StatusBarSO> statusBarList = new List<StatusBarSO>();

    // Start is called before the first frame update
    void Start()
    {
        //GET ALL ASSETS
        statusBarList.AddRange(ResourceIndex.GetAllAssets<StatusBarSO>());
    }

    #region UI_EVENT_CALLS
    void OnStatusBarCurrentValueUpdated(string name,float newVal){

    }

    void OnStatusBarMaxValueUpdated(string name,float newVal){

    }
    #endregion

    public StatusBarSO GetStatusBar(string name)
    {
        for(int i = 0;i<statusBarList.Count;i++){
            if(statusBarList[i].GetBarName() == name){
                return statusBarList[i];
            }
        }
        return null;
    }

    public void SetStatusBarMaxValue(string name, float val){
        StatusBarSO statusBar = GetStatusBar(name);
        if(!statusBar){
            Debug.LogWarning("Could not find status bar " + name + "!");
            return;
        }

        statusBar.SetBarMaxValue(val);
        OnStatusBarMaxValueUpdated(name,statusBar.GetBarMaxValue());
    }

    public void SetStatusBarCurrentValue(string name, float val){
        StatusBarSO statusBar = GetStatusBar(name);
        if(!statusBar){
            Debug.LogWarning("Could not find status bar " + name + "!");
            return;
        }

        statusBar.SetBarCurrentValue(val);
        OnStatusBarCurrentValueUpdated(name,statusBar.GetBarCurrentValue());
    }
}
