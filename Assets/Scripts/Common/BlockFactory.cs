using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockFactory : MonoBehaviour
{
    public GameObject[] blockPrefabs;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            int rnd = Random.Range(0, blockPrefabs.Length);
            var block = Instantiate(blockPrefabs[rnd]);
            block.GetComponent<BlockView>().blockModel.isSelected = true;
        }
    }
}
