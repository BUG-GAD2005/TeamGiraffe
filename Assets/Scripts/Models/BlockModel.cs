using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class BlockModel : IBlockModel
{
    public bool isSelected = false;
    private Dictionary<Vector3Int, GameObject> tiles = new Dictionary<Vector3Int, GameObject>();

    public Dictionary<Vector3Int, GameObject> GetTiles()
    {
        return tiles;
    }

    public void AddTile(Vector3Int tilePos, GameObject obj)
    {
        tiles.Add(tilePos, obj);
    }
}
