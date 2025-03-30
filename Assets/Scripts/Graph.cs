using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class Graph : MonoBehaviour {
    public Cell[,] cells;

    int[,] mapData;
    public int mapWidth = -1;
    public int mapHeight = -1;

    public static readonly Vector2[] allDirections = {
        new Vector2(0f, 1f),
        new Vector2(1f, 1f),
        new Vector2(1f, 0f),
        new Vector2(1f, -1f),
        new Vector2(0f, -1f),
        new Vector2(-1f, -1f),
        new Vector2(-1f, 0f),
        new Vector2(-1f, 1f)
    };

    public void init(int[,] mapData) {
        this.mapData = mapData;
        mapWidth = mapData.GetLength(0);
        mapHeight = mapData.GetLength(1);
        cells = new Cell[mapWidth, mapHeight];

        for (int y = 0; y < mapHeight; y++) {
            for (int x = 0; x < mapWidth; x++) {
                CellState nodeType = (CellState)mapData[x, y];
                Cell newNode = new Cell(x, y, nodeType);
                cells[x, y] = newNode;
                newNode.position = new Vector3(x, 0, y);
            }
        }

        for (int y = 0; y < mapHeight; y++) {
            for (int x = 0; x < mapWidth; x++) {
                cells[x, y].neighbors = getNeighbors(x, y, cells);
            }
        }
    }

    public bool isInRange(int x, int y) {
        return (x >= 0 && x < mapWidth && y >= 0 && y < mapHeight);
    }

    List<Cell> getNeighbors(int x, int y, Cell[,] nodeArray) {
        List<Cell> neighborNodes = new List<Cell>();
        foreach (Vector2 d in allDirections) {
            int newX = x + (int)d.x; // new x for the direction we are looking in
            int newY = y + (int)d.y; // new y for the direction we are looking in

            if (isInRange(newX, newY) &&
                nodeArray[newX, newY] != null &&
                nodeArray[newX, newY].cellState == CellState.ALIVE) {
                neighborNodes.Add(nodeArray[newX, newY]);
            }
        }
        return neighborNodes;
    }
}
