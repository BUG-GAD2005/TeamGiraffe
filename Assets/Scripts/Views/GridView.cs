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

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
        }
    }
}
