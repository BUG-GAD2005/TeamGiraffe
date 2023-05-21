using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController
{
    Dictionary<Vector3Int, GameObject> gridPlacement = new Dictionary<Vector3Int, GameObject>();

    public void SubscribeEvents()
    {
        EventController.Instance.OnBlockPlacementGrid += ValidateBlockPlacement;
    }

    private bool ValidateBlockPlacement(Vector3Int position, IBlockModel blockData)
    {
        foreach (var blockTile in blockData.GetTiles())
        {
            Vector3Int finalPosition = position + blockTile.Key;
            if (!gridPlacement.TryGetValue(finalPosition, out GameObject existing))
                return false;

            if (existing != null)
                return false;
        }

        foreach (var blockTile in blockData.GetTiles())
        {
            Vector3Int finalPosition = position + blockTile.Key;
            gridPlacement[finalPosition] = blockTile.Value;
        }

        return true;
    }

    public void InitializeGridCell(Vector3Int cell)
    {
        gridPlacement.Add(cell, null);
    }
}
