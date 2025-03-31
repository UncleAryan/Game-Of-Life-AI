using System.Collections.Generic;
using UnityEngine;

public class GraphView : MonoBehaviour {
    public GameObject cellViewPrefab;
    public Color aliveColor = Color.white;
    public Color deadColor = Color.black;
    public CellView[,] cellViews;

    public void init(Graph graph) {
        cellViews = new CellView[graph.mapWidth, graph.mapHeight];

        // go through each node in the nodes array in Graph class
        foreach (Cell cell in graph.cells) {
            GameObject instance = Instantiate(cellViewPrefab, Vector3.zero, Quaternion.identity);
            CellView cellView = instance.GetComponent<CellView>();

            if (cellView != null) {
                cellView.init(cell);
                cellViews[cell.xIndex, cell.yIndex] = cellView;
                if (cell.cellState == CellState.DEAD) {
                    cellView.colorCell(deadColor);
                }
                else {
                    cellView.colorCell(aliveColor);
                }
            }
        }
    }

    public void colorCell(Cell cell, Color color) {
        CellView cellView = cellViews[cell.xIndex, cell.yIndex];
        if (cellView != null) {
            cellView.colorCell(color);
        }
    }
}
