using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour
{
    public event Func<Vector3Int, IBlockModel, bool> OnBlockPlacementGrid;

    public bool? TryPlacementOnGrid(Vector3Int position, IBlockModel blockData)
    {
        return OnBlockPlacementGrid?.Invoke(position, blockData);
    }

    public static EventController Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
}
