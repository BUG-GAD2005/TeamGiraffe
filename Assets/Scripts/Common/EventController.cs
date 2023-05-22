using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour
{
    public event Func<Vector3Int, IBlockModel, bool> OnValidateBlockPlacement;
    public event Func<IBlockModel, bool> OnValidateAllPlacements;
    public event Action<Transform> OnBlockPlacement;
    public event Action<Transform> OnBlockPlaced;
    

    public bool? TryPlacementOnGrid(Vector3Int position, IBlockModel blockData)
    {
        return OnValidateBlockPlacement?.Invoke(position, blockData);
    }

    public bool? ValidateAllPlacements(IBlockModel blockModel)
    {
        return OnValidateAllPlacements?.Invoke(blockModel);
    }


    public void PlaceBlock(Transform block)
    {
        OnBlockPlacement?.Invoke(block);
    }

    public void PlacedBlock(Transform block)
    {
        OnBlockPlaced?.Invoke(block);
    }


    public static EventController Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
}
