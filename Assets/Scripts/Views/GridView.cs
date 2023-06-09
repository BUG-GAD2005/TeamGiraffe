using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridView : MonoBehaviour
{
    public GridModel model;
    private GridController controller;

    private void Awake()
    {
        controller = new GridController(this, model);
    }

    private void Start()
    {
        CreateGridView();
        controller.SubscribeEvents();
    }

    void CreateGridView()
    {
        for (int i = 0; i < model.rowCount; i++)
        {
            for (int j = 0; j < model.columnCount; j++)
            {
                Vector3Int pos = new Vector3Int(j, 0, i);
                GameObject cellObj = Instantiate(model.tilePrefab, transform);
                cellObj.name = pos.z + "_" + pos.x;
                cellObj.transform.localPosition = pos;
                controller.InitializeGridCell(pos);
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

        DestroyImmediate(block.gameObject);
    }

    public void ClearTiles(Dictionary<Vector3Int,GameObject> tiles)
    {
        foreach (var tileObj in tiles.Values)
        {
            DestroyImmediate(tileObj);
        }
    }

    private void Update()
    {
    }
}
