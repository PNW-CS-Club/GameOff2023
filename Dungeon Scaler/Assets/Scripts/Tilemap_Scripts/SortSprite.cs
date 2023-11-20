using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SortSprite : MonoBehaviour
{
    public Vector3 pos; //debug
    public Vector3Int tilePos; //debug
    public TileBase tileBase; //debug
    public Vector3Int playerPos; //debug
    public float newZ; //debug
    public int spriteZ = 0;

    Grid grid;
    Tilemap tilemap;

    void Start() {
        grid = GameObject.FindWithTag("Grid").GetComponent<Grid>();
        tilemap = GameObject.FindWithTag("Tilemap").GetComponent<Tilemap>();
    }

    void Update() {
        pos = new Vector3(transform.position.x, transform.position.y, 0);
        tilePos = tilemap.WorldToCell(pos);

        for (int i = 0; i < 100; i++) {
            tileBase = tilemap.GetTile(tilePos);
            if (tileBase != null) {
                playerPos = tilePos;
                playerPos.z++;
            }
            tilePos = new Vector3Int(tilePos.x - 1, tilePos.y - 1, tilePos.z + 1);
        }

        newZ = tilemap.CellToWorld(playerPos).z;
        transform.position = new Vector3(transform.position.x, transform.position.y, newZ);
    }
}