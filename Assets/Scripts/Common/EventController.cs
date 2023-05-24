using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour
{
    // Grid validation
    public event Func<Vector3Int, IBlockModel, bool> OnValidateBlockPlacement;
    public event Func<IBlockModel, bool> OnValidateAllPlacements;

    // Block placement
    public event Action<Transform> OnBlockPlacement;
    public event Action<Transform> OnBlockPlaced;
    public event Action<IBlockModel> OnBlockPlacementFailed;

    // Game/UI state
    public event Action<int> OnScoreEarned;
    public event Action OnGameOver;


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

    public void FailedBlockPlacement(IBlockModel blockModel)
    {
        OnBlockPlacementFailed?.Invoke(blockModel);
    }

    public void EarnScore(int score)
    {
        OnScoreEarned?.Invoke(score);
    }

    public void LoseGame()
    {
        OnGameOver?.Invoke();
    }

    public static EventController Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
}
