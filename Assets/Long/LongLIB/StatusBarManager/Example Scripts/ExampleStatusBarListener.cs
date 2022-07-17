using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleStatusBarListener : MonoBehaviour
{
    void Start()
    {
        //Listen to events from the manager
        StatusBarManager.StartListening("StatusBarCurrValueChanged",StatusBarMaxValueUpdate);
        StatusBarManager.StartListening("StatusBarMaxValueChanged",StatusBarCurrValueUpdate);

        //Update status bars
        StatusBarManager.Instance.SetStatusBarMaxValue("PlayerHealth",100);
        StatusBarManager.Instance.SetStatusBarCurrentValue("PlayerHealth",50);
        StatusBarManager.Instance.AddStatusBarValue("PlayerHealth",25);
        StatusBarManager.Instance.AddStatusBarValue("PlayerHealth",-10);

        Debug.Log("Debug TEST");
    }

    void StatusBarMaxValueUpdate(string name, float val){
    }
    void StatusBarCurrValueUpdate(string name, float val){
    }
}
