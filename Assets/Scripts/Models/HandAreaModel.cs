using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class HandAreaModel
{
    public BlockFactory blockFactory;
    public Transform[] spawnPoints;
    public IBlockModel[] blocksList;
    public Vector3[] spawnOffsets;
}
