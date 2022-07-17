using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//Listens to events specified under StatusBarName
public class StatusBarUIListener : MonoBehaviour
{
    [SerializeField] string statusBarName;
    public UnityEvent<float> OnStatusBarMaxValueUpdated;
    public UnityEvent<float> OnStatusBarCurrValueUpdated;

    void Start()
    {
        //Listen to events from the manager
        StatusBarManager.StartListening("StatusBarCurrValueChanged",StatusBarCurrValueUpdate);
        StatusBarManager.StartListening("StatusBarMaxValueChanged",StatusBarMaxValueUpdate);
    }
    void StatusBarMaxValueUpdate(string name, float val){
        if(name == statusBarName){
            OnStatusBarMaxValueUpdated.Invoke(val);
        }
    }
    void StatusBarCurrValueUpdate(string name, float val){
        if(name == statusBarName){
            OnStatusBarCurrValueUpdated.Invoke(val);
        }
    }
}
