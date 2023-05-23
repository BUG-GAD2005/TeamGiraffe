using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class HandAreaView : MonoBehaviour
{
    public HandAreaModel model;
    private HandAreaController controller;

    private void Awake()
    {
        model.blocksList = new IBlockModel[model.spawnPoints.Length];
        model.spawnOffsets = new Vector3[model.spawnPoints.Length];

        controller = new HandAreaController(this, model);
    }

    private void Start()
    {
        controller.SubscribeEvents();

        EventController.Instance.OnBlockPlacementFailed += PositionBlockToSpawn;
        SpawnBlockPrefab();
    }

    public void SpawnBlockPrefab()
    {
        for (int i = 0; i < model.blocksList.Length; i++)
        {
            BlockView blockPrefab = model.blockFactory.GetRandomBlockPrefab();
            float maxZ = blockPrefab.blockModel.GetTiles().Keys.OrderByDescending(b => b.z).First().z;
            if (maxZ >= 3)
                model.spawnOffsets[i] = new Vector3(0, 0, -(maxZ - 1f));
            else
                model.spawnOffsets[i] = Vector3.zero;

            blockPrefab.transform.parent = model.spawnPoints[i];
            blockPrefab.transform.localPosition = model.spawnOffsets[i];
            model.blocksList[i] = blockPrefab.blockModel;

        }

        if(!controller.CanPlaceAnyBlock())
        {
            Debug.Log("Gamo Over");
        }
    }

    private void PositionBlockToSpawn(IBlockModel blockModel)
    {
        int blockIndex = Array.IndexOf(model.blocksList, blockModel);
        Vector3 spawnOffset = model.spawnOffsets[blockIndex];
        Transform spawnPoint = model.spawnPoints[blockIndex];

        spawnPoint.GetChild(0).transform.localPosition = spawnOffset;
    }
}
