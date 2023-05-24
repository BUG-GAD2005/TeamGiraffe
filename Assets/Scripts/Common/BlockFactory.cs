using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BlockFactory : MonoBehaviour
{
    public GameObject[] blockPrefabs;

    public BlockView GetRandomBlockPrefab()
    {
        int rnd = Random.Range(0, blockPrefabs.Length);
        return Instantiate(blockPrefabs[rnd]).GetComponent<BlockView>();
    }
}
