using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StatusBarManager : Singleton<StatusBarManager>
{
    //MAKE SURE TO SET HIGHER IN SCRIPT EXECUTION ORDER

    List<StatusBarSO> statusBarList = new List<StatusBarSO>();

    void Start()
    {
        //GET ALL ASSETS
        statusBarList.AddRange(ResourceIndex.GetAllAssets<StatusBarSO>());
    }

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
        TriggerEvent("StatusBarMaxValueChanged",name,statusBar.GetBarMaxValue());
    }

    public void SetStatusBarCurrentValue(string name, float val){
        StatusBarSO statusBar = GetStatusBar(name);
        if(!statusBar){
            Debug.LogWarning("Could not find status bar " + name + "!");
            return;
        }

        statusBar.SetBarCurrentValue(val);
        TriggerEvent("StatusBarCurrValueChanged",name,statusBar.GetBarCurrentValue());
    }

    public void AddStatusBarValue(string name, float val){
        StatusBarSO statusBar = GetStatusBar(name);
        if(!statusBar){
            Debug.LogWarning("Could not find status bar " + name + "!");
            return;
        }

        statusBar.AddBarValue(val);

        Debug.Log(statusBar.GetBarCurrentValue());
        TriggerEvent("StatusBarCurrValueChanged",name,statusBar.GetBarCurrentValue());
    }

    public void AddStatusBarMaxValue(string name, float val){
        StatusBarSO statusBar = GetStatusBar(name);
        if(!statusBar){
            Debug.LogWarning("Could not find status bar " + name + "!");
            return;
        }

        statusBar.AddBarMaxValue(val);

        Debug.Log(statusBar.GetBarCurrentValue());
        TriggerEvent("StatusBarMaxValueChanged",name,statusBar.GetBarMaxValue());
    }


    #region LISTENERS
    private Dictionary <string, UnityEvent<string,float>> eventDictionary = new Dictionary<string, UnityEvent<string,float>>();

    public static void StartListening (string eventName, UnityAction<string,float> listener)
    {
        UnityEvent<string,float> thisEvent = null;
        if (Instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new UnityEvent<string,float>();
            thisEvent.AddListener(listener);
            Instance.eventDictionary.Add(eventName, thisEvent);
        }
    }

    public static void StopListening (string eventName, UnityAction<string,float> listener)
    {
        if (Instance == null) return;

        UnityEvent<string,float> thisEvent = null;
        if (Instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }

    public static void TriggerEvent (string eventName, string barName,float barValue)
    {
        UnityEvent<string,float> thisEvent = null;

        if (Instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.Invoke(barName,barValue);
        }
        else
        {
            Debug.LogError($"{eventName} does not exist!");
        }
    }
    #endregion
}
