using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController
{
    public void TryGridPlacement(Vector3Int position, BlockModel model)
    {
        bool? placementResult = EventController.Instance.TryPlacementOnGrid(position, model);
        if (placementResult == true)
        {
            model.isSelected = false;
            Debug.Log("Placed");
        }
        else
            Debug.LogError("Not placed");
    }
}
