using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController
{
    public void TryGridPlacement(Transform block, BlockModel model)
    {
        bool? placementResult = EventController.Instance.TryPlacementOnGrid(Vector3Int.RoundToInt(block.position), model);
        if (placementResult == true)
        {
            model.isSelected = false;
            EventController.Instance.PlaceBlock(block);
        }
        else
        {
            model.isSelected = false;
            EventController.Instance.FailedBlockPlacement(model);
        }
    }
}
