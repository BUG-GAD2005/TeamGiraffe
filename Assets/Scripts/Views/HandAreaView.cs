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
        SpawnBlockPrefab();
    }

    private void Update()
    {
        CheckHandAreaBlocks();
    }

    private void SpawnBlockPrefab()
    {
        GameObject blockPrefab = handAreaModel.blockFactory.GetRandomBlockPrefab();
        GameObject blockPrefab2 = handAreaModel.blockFactory.GetRandomBlockPrefab();
        GameObject blockPrefab3 = handAreaModel.blockFactory.GetRandomBlockPrefab();

        blockPrefab.transform.parent = handAreaModel.spawnPoints[0];
        blockPrefab2.transform.parent = handAreaModel.spawnPoints[1];
        blockPrefab3.transform.parent = handAreaModel.spawnPoints[2];
    }

    private void CheckHandAreaBlocks()
    {
        if(handAreaModel.spawnPoints[0].childCount == 0 && handAreaModel.spawnPoints[1].childCount == 0 && handAreaModel.spawnPoints[2].childCount == 0)
        {
            SpawnBlockPrefab();
        }
    }
}
