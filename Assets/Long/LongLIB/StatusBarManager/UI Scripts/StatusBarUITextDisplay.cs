using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusBarUITextDisplay : MonoBehaviour
{
    public Text textComponent;
    public void SetText(float value){
        textComponent.text = value.ToString();
    }
}
