using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAreaView : MonoBehaviour
{
    public HandAreaModel handAreaModel;
    private HandAreaController handAreaController;

    private void Awake()
    {
        handAreaController = new HandAreaController();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        //GameObject blockPrefab = handAreaModel.blockFactory.GetRandomBlockPrefab();
        //blockPrefab.transform.parent = handAreaModel.spawnPoints[0];
    }
}
