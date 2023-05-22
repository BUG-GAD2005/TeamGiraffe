using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BlockFactory : MonoBehaviour
{
    public GameObject[] blockPrefabs;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            int rnd = Random.Range(0, blockPrefabs.Length);
            var block = Instantiate(blockPrefabs[rnd]);
            block.GetComponent<BlockView>().blockModel.isSelected = true;
        }
    }

    public BlockView GetRandomBlockPrefab()
    {
        int rnd = Random.Range(0, blockPrefabs.Length);
        return Instantiate(blockPrefabs[rnd]).GetComponent<BlockView>();
    }
}
