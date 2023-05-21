using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockView : MonoBehaviour
{
    public BlockModel blockModel;
    private BlockController blockController;

    private void Awake()
    {
        blockController = new BlockController();
        SetupBlocks();
    }

    void SetupBlocks()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform childTile = transform.GetChild(i);
            Vector3Int tilePos = Vector3Int.RoundToInt(childTile.position);
            blockModel.AddTile(tilePos, childTile.gameObject);
        }
    }

    void Update()
    {
        if (blockController == null)
            Debug.Log("null");
        if(blockModel.isSelected)
        {
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
            if(Input.GetMouseButtonDown(0))
            {
                Vector3Int roundPos = Vector3Int.RoundToInt(transform.position);
                transform.position = roundPos;
                blockController.TryGridPlacement(roundPos, blockModel);
            }
        }
    }
}
