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
        handAreaModel.blocksList = new IBlockModel[transform.childCount];
    }

    private void Start()
    {
        EventController.Instance.OnBlockPlaced += CheckHandAreaBlocks;
        SpawnBlockPrefab();
    }

    private void Update()
    {
    }

    private void SpawnBlockPrefab()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            BlockView blockPrefab = handAreaModel.blockFactory.GetRandomBlockPrefab();
            blockPrefab.transform.parent = handAreaModel.spawnPoints[i];
            blockPrefab.transform.position = handAreaModel.spawnPoints[i].position;
            handAreaModel.blocksList[i] = blockPrefab.blockModel;
        }
    }

    private void CheckHandAreaBlocks(Transform block)
    {
        bool canPlaceAll = true;
        for (int i = 0; i < transform.childCount; i++)
        {
            if (handAreaModel.spawnPoints[i].childCount == 0)
                continue;

            bool? placeResult = EventController.Instance.ValidateAllPlacements(handAreaModel.blocksList[i]);
            if(placeResult == false)
            {
                canPlaceAll = false;
                break;
            }
        }

        if(!canPlaceAll)
        {
            // Game OVer Screen
            Debug.Log("Game Over");
        }
        else if(handAreaModel.spawnPoints[0].childCount == 0 && handAreaModel.spawnPoints[1].childCount == 0 && handAreaModel.spawnPoints[2].childCount == 0)
        {
            SpawnBlockPrefab();
        }
    }
}
