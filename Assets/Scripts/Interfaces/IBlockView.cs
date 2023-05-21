using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBlockModel
{
    public void AddTile(Vector3Int tilePos, GameObject obj);
    public Dictionary<Vector3Int, GameObject> GetTiles();
}
