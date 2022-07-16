using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusBarManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //GET ALL ASSETS
        List<StatusBarSO> allResources = new List<StatusBarSO>();
        allResources.AddRange(ResourceIndex.GetAllAssets<StatusBarSO>());
    }

    // Update is called once per frame
    void Update()
    {

    }
}
