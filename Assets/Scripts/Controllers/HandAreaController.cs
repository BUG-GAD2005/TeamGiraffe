using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HandAreaController
{
    HandAreaView view;
    HandAreaModel model;

    public HandAreaController(HandAreaView view, HandAreaModel model)
    {
        this.view = view;
        this.model = model;
    }

    public void SubscribeEvents()
    {
        EventController.Instance.OnBlockPlaced += CheckHandAreaBlocks;
    }

    public bool CanPlaceAnyBlock()
    {
        bool canPlaceAny = true;
        for (int i = 0; i < model.blocksList.Length; i++)
        {
            if (model.spawnPoints[i].childCount == 0)
                continue;

            canPlaceAny = false;
            bool? placeResult = EventController.Instance.ValidateAllPlacements(model.blocksList[i]);
            if (placeResult == true || !placeResult.HasValue)
            {
                canPlaceAny = true;
                break;
            }
        }

        return canPlaceAny;
    }

    public void CheckHandAreaBlocks(Transform block)
    {
        if (!CanPlaceAnyBlock())
        {
            EventController.Instance.LoseGame();
        }
        else if (model.spawnPoints[0].childCount == 0 && model.spawnPoints[1].childCount == 0 && model.spawnPoints[2].childCount == 0)
        {
            view.SpawnBlockPrefab();
        }
    }
}
