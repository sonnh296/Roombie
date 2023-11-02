using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class SimpleRandomWalkDeguonGenerator : AbstractDeguonGenerator
{
    [SerializeField]
    protected SimpleRandomWalkSO randomWalkParameters;

    protected override void RunProceduralGeneration() {
        HashSet<Vector2Int> floorPositions = RunRandomWalk(randomWalkParameters, startPosition);
        tilemapVisualizer.clear();
        tilemapVisualizer.PaintFloorTiles(floorPositions);
        WallGenerator.CreateWalls(floorPositions, tilemapVisualizer);
    }

    protected HashSet<Vector2Int> RunRandomWalk(SimpleRandomWalkSO parameters, Vector2Int position) {
        var currentPosition = position;
        HashSet<Vector2Int> floorPosition =  new HashSet<Vector2Int>();
        for (int i = 0; i < parameters.iteration; i++) {
            var path = ProceduralAlgorithm.SimpleRandomWalk(currentPosition, parameters.walkLength);
            floorPosition.UnionWith(path);
            if(parameters.startRandomEachIteration) {
                currentPosition = floorPosition.ElementAt(Random.Range(0, floorPosition.Count));
            }
        }
        return floorPosition;
    }
}
