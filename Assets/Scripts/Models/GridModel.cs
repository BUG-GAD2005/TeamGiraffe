using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GridModel
{
    [SerializeField] public int rowCount;
    [SerializeField] public int columnCount;
    [SerializeField] public GameObject tilePrefab;
}
