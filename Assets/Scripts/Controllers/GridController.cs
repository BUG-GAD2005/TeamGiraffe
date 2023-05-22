using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GridController
{
    GridView view;
    Dictionary<Vector3Int, GameObject> gridPlacement = new Dictionary<Vector3Int, GameObject>();

    public GridController(GridView view)
    {
        this.view = view;
    }

    public void SubscribeEvents()
    {
        EventController.Instance.OnValidateBlockPlacement += ValidateBlockPlacement;
        EventController.Instance.OnBlockPlacement += PlaceBlockOnGrid;
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

        return true;
    }

    public void PlaceBlockOnGrid(Transform block)
    {
        Vector3Int position = Vector3Int.RoundToInt(block.position);

        for (int i = 0; i < block.childCount; i++)
        {
            Transform tile = block.GetChild(i);

            Vector3Int tilePosition = Vector3Int.RoundToInt(tile.position);
            gridPlacement[tilePosition] = tile.gameObject;
        }

        view.HandleBlockPlacementView(block);
        CheckCompletedLines();
    }

    private void CheckCompletedLines()
    {
    }

    public void InitializeGridCell(Vector3Int cell)
    {
        gridPlacement.Add(cell, null);
    }
}
