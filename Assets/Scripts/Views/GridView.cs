using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridView : MonoBehaviour
{
    public GridModel gridModel;
    private GridController gridController;

    private void Awake()
    {
        gridController = new GridController(this, gridModel);
    }

    private void Start()
    {
        CreateGridView();
        gridController.SubscribeEvents();
    }

    void CreateGridView()
    {
        for (int i = 0; i < gridModel.rowCount; i++)
        {
            for (int j = 0; j < gridModel.columnCount; j++)
            {
                Vector3Int pos = new Vector3Int(j, 0, i);
                GameObject cellObj = Instantiate(gridModel.tilePrefab, transform);
                cellObj.name = pos.z + "_" + pos.x;
                cellObj.transform.localPosition = pos;
                gridController.InitializeGridCell(pos);
            }
        }
    }

    public void HandleBlockPlacementView(Transform block)
    {
        int childC = block.childCount;
        for (int i = 0; i < childC; i++)
        {
            block.GetChild(0).parent = transform;
        }

        Destroy(block.gameObject);
    }

    public void ClearTiles(Dictionary<Vector3Int,GameObject> tiles)
    {
        foreach (var tileObj in tiles.Values)
        {
            Destroy(tileObj);
        }
    }

    private void Update()
    {
    }
}
