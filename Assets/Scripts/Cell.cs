using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public enum CellState {
    DEAD = 0,
    ALIVE = 1
}
public class Cell {
    public CellState cellState;
    public int xIndex;
    public int yIndex;
    public Vector3 position;
    public List<Cell> neighbors;

    public Cell(int x, int y, CellState state) {
        xIndex = x; 
        yIndex = y;
        cellState = state;
        neighbors = new List<Cell>();
    }
}
