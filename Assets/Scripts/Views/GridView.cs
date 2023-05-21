using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridView : MonoBehaviour
{
    public GridModel gridModel;
    private GridController gridController;

    private void Awake()
    {
        gridController = new GridController();
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

    private void Update()
    {
    }
}
