using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour
{
    public event Func<Vector3Int, IBlockModel, bool> OnValidateBlockPlacement;
    public event Action<Transform> OnBlockPlacement;

    public bool? TryPlacementOnGrid(Vector3Int position, IBlockModel blockData)
    {
        return OnValidateBlockPlacement?.Invoke(position, blockData);
    }

    public void PlaceBlock(Transform block)
    {
        OnBlockPlacement?.Invoke(block);
    }

    public static EventController Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
}
