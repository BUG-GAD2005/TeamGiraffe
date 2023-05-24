using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockView : MonoBehaviour
{
    public BlockModel model;
    private BlockController controller;

    private void Awake()
    {
        controller = new BlockController();
        SetupBlocks();
    }

    void SetupBlocks()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform childTile = transform.GetChild(i);
            Vector3Int tilePos = Vector3Int.RoundToInt(childTile.position);
            model.AddTile(tilePos, childTile.gameObject);
        }
    }

    void Update()
    {
        if(model.isSelected)
        {
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
            if(Input.GetMouseButtonDown(0))
            {
                Vector3Int roundPos = Vector3Int.RoundToInt(transform.position);
                roundPos.y = 0;
                transform.position = roundPos;
                transform.position += Vector3.up * 0.01f;

                controller.TryGridPlacement(transform, model);
            }
        }
    }

    private void OnMouseDown()
    {
        if (!model.isSelected)
        {
            Invoke(nameof(SetSelected), 0.1f);
        }
    }

    private void SetSelected()
    {
        model.isSelected = true;
    }
}
