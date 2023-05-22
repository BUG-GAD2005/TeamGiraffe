using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GridController
{
    GridView view;
    GridModel model;
    Dictionary<Vector3Int, GameObject> gridPlacement = new Dictionary<Vector3Int, GameObject>();

    public GridController(GridView view, GridModel model)
    {
        this.view = view;
        this.model = model;
    }

    public void SubscribeEvents()
    {
        EventController.Instance.OnValidateBlockPlacement += ValidateBlockPlacement;
        EventController.Instance.OnBlockPlacement += PlaceBlockOnGrid;
        EventController.Instance.OnValidateAllPlacements += ValidateAllPlacements;
    }

    private bool ValidateBlockPlacement(Vector3Int position, IBlockModel blockData)
    {
        foreach (var blockTile in blockData.GetTiles())
        {
            Vector3Int finalPosition = position + blockTile.Key;
            if (!gridPlacement.TryGetValue(finalPosition, out GameObject existing) || existing != null)
                return false;
        }

        return true;
    }

    private bool ValidateAllPlacements(IBlockModel blockData)
    {
        bool result = false;
        foreach (var cellPos in gridPlacement)
        {
            bool canPlace = true;
            foreach (var blockTile in blockData.GetTiles())
            {
                Vector3Int finalPosition = cellPos.Key + blockTile.Key;
                if (!gridPlacement.TryGetValue(finalPosition, out GameObject existing) || existing != null)
                {
                    canPlace = false;
                    break;
                }
            }

            if (canPlace)
            {
                result = true;
                break;
            }
        }

        return result;
    }

    public void PlaceBlockOnGrid(Transform block)
    {
        List<Vector3Int> tilePoses = new List<Vector3Int>();
        Vector3Int position = Vector3Int.RoundToInt(block.position);
        for (int i = 0; i < block.childCount; i++)
        {
            Transform tile = block.GetChild(i);

            Vector3Int tilePosition = Vector3Int.RoundToInt(tile.position);
            tilePoses.Add(tilePosition);
            gridPlacement[tilePosition] = tile.gameObject;
        }

        view.HandleBlockPlacementView(block);
        CheckCompletedLines(tilePoses);
        EventController.Instance.PlacedBlock(block);
    }

    private void CheckCompletedLines(List<Vector3Int> newTilePoses)
    {
        Dictionary<Vector3Int, GameObject> toDestroy = new Dictionary<Vector3Int, GameObject>();
        for (int i = 0; i < newTilePoses.Count; i++)
        {
            bool lineDone = false;
            List<Vector3Int> tileList = new List<Vector3Int>();
            Vector3Int tilePos = newTilePoses[i];
            Vector3Int startPos = tilePos;
            startPos.x = 0;

            for (int j = 0; j < model.columnCount; j++)
            {
                Vector3Int checkPos = startPos + Vector3Int.right * j;
                if (checkPos == tilePos)
                    continue;

                if (gridPlacement[checkPos] == null)
                    break;

                tileList.Add(checkPos);
            }

            if(tileList.Count == model.columnCount - 1) // Full horizontal
            {
                foreach (var item in tileList)
                {
                    if (!toDestroy.ContainsKey(item))
                        toDestroy.Add(item, gridPlacement[item]);
                }
                lineDone = true;
            }

            tileList = new List<Vector3Int>();
            startPos = tilePos;
            startPos.z = 0;

            for (int j = 0; j < model.rowCount; j++)
            {
                Vector3Int checkPos = startPos + Vector3Int.forward * j;
                if (checkPos == tilePos)
                    continue;

                if (gridPlacement[checkPos] == null)
                    break;

                tileList.Add(checkPos);
            }

            if (tileList.Count == model.rowCount - 1) // Full vertical
            {
                foreach (var item in tileList)
                {
                    if (!toDestroy.ContainsKey(item))
                        toDestroy.Add(item, gridPlacement[item]);
                }
                lineDone = true;
            }

            if (lineDone && !toDestroy.ContainsKey(tilePos))
                toDestroy.Add(tilePos, gridPlacement[tilePos]);

        }

        if (toDestroy.Count > 0)
            view.ClearTiles(toDestroy);
    }

    public void InitializeGridCell(Vector3Int cell)
    {
        gridPlacement.Add(cell, null);
    }
}
