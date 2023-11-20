using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SortSprite : MonoBehaviour
{
    public Vector3 relativePos; //debug
    public Vector3 pos; //debug
    public int characterZ = 0; //debug

    Grid grid;

    void Start() {
        grid = GameObject.FindWithTag("Grid").GetComponent<Grid>();
    }

    void Update() {
        pos = new Vector3(transform.position.x, transform.position.y, 0);
        Vector3Int tilepos = grid.WorldToCell(pos);
        Vector3 tileworldpos = grid.CellToWorld(tilepos);
        relativePos = pos - tileworldpos;
        if (relativePos.y < .25)
            transform.position = new Vector3(transform.position.x, transform.position.y, 1 + characterZ);
        else
            transform.position = new Vector3(transform.position.x, transform.position.y, 2 + characterZ);
    }
}