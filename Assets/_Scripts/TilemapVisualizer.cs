using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapVisualizer : MonoBehaviour
{
    [SerializeField]
    private Tilemap floorTilemap, wallTileMap;
    [SerializeField]
    private TileBase floorTile, wallTop;

    public void PaintFloorTiles(IEnumerable<Vector2Int> floorPositions) {
        PainTiles(floorPositions, floorTilemap, floorTile);
    }

    private void PainTiles(IEnumerable<Vector2Int> positions, Tilemap tilemap, TileBase tile) {
        foreach(var position in positions) {
            PainSingleTile(tilemap, tile, position);
        }
    }

    private void PainSingleTile(Tilemap tilemap, TileBase tile, Vector2Int position) {
        var tilePosition = tilemap.WorldToCell((Vector3Int)position);
        tilemap.SetTile(tilePosition, tile);
    }

    public void clear() {
        floorTilemap.ClearAllTiles();
        wallTileMap.ClearAllTiles();
    }

    internal void PainSingleBasicWall(Vector2Int position) {
        PainSingleTile(wallTileMap, wallTop, position);

    }
}
