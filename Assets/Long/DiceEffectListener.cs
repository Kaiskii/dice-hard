using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceEffectListener : MonoBehaviour
{
    void Start()
    {
        DiceEffectManager.StartListening("OnAttackEvent", OnAttackIncreased);
        DiceEffectManager.StartListening("OnHealEvent", OnHeal);

        StatusBarManager.Instance.SetStatusBarMaxValue("PlayerDamage",100);
        StatusBarManager.Instance.SetStatusBarCurrentValue("PlayerDamage",1);

        StatusBarManager.Instance.SetStatusBarMaxValue("PlayerHealth",100);
        StatusBarManager.Instance.SetStatusBarCurrentValue("PlayerHealth",100);

        StatusBarManager.Instance.SetStatusBarMaxValue("EnemyDamage",5);
        StatusBarManager.Instance.SetStatusBarCurrentValue("EnemyDamage",5);

        StatusBarManager.Instance.SetStatusBarMaxValue("EnemyHealth",10);
        StatusBarManager.Instance.SetStatusBarCurrentValue("EnemyHealth",10);
    }

    void OnAttackIncreased(int val){
        StatusBarManager.Instance.AddStatusBarValue("PlayerDamage",val);
        StatusBarManager.Instance.AddStatusBarMaxValue("PlayerDamage",val);
    }

    void OnHeal(int val){
        Debug.Log("VALUE: " + val);
        StatusBarManager.Instance.AddStatusBarValue("PlayerHealth",val);
        StatusBarManager.Instance.AddStatusBarMaxValue("PlayerHealth",val);
    }
}
