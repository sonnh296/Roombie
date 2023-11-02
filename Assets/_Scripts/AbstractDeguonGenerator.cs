using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractDeguonGenerator : MonoBehaviour
{
    [SerializeField]
    protected TilemapVisualizer tilemapVisualizer = null;
    [SerializeField]
    protected Vector2Int startPosition = Vector2Int.zero;

    public void GenerateDeguon() {
        tilemapVisualizer.clear();
        RunProceduralGeneration();
    }
    protected abstract void RunProceduralGeneration();
}
