using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Tick : MonoBehaviour {
    private Graph graph;
    private GraphView graphView;

    public int generation;
    public int population;

    public Color aliveColor = Color.white;
    public Color deadColor = Color.black;

    public bool pause;

    private Cell[,] nextGeneration;
    public void init(Graph graph, GraphView graphView) {
        this.graph = graph;
        this.graphView = graphView;

        generation = 0;
        population = graph.getNumberOfAliveCells();

        pause = false;

        nextGeneration = graph.cells;

        showColor();
    }

    public IEnumerator tickRoutine(float timeStep = 0.1f) {
        while(!pause) {
            tickGeneration();
            updateEverything();
            yield return new WaitForSeconds(timeStep);
            showColor();
        }
    }

    private void updateEverything() {
        graph.cells = nextGeneration;
        graph.updateNeighbors();
        generation++;
        population = graph.getNumberOfAliveCells();
    }

    private void tickGeneration() {
        for (int i = 0; i < graph.mapWidth; i++) {
            for (int j = 0; j < graph.mapHeight; j++) {
                if (i == 0 || i == graph.mapWidth - 1 || j == 0 || j == graph.mapHeight - 1) {
                    nextGeneration[i, j].cellState = graph.cells[i, j].cellState;
                }

                if (graph.cells[i, j].cellState == CellState.DEAD &&
                    graph.cells[i, j].neighbors.Count == 3) {
                    nextGeneration[i, j].cellState = CellState.ALIVE;
                } else if (graph.cells[i, j].cellState == CellState.ALIVE &&
                          (graph.cells[i, j].neighbors.Count < 2 ||
                           graph.cells[i, j].neighbors.Count > 3)) {
                    nextGeneration[i, j].cellState = CellState.DEAD;
                } else {
                    nextGeneration[i, j].cellState = graph.cells[i, j].cellState;
                }
            }
        }
    }

    private void showColor(GraphView graphView) {
        foreach(Cell cell in graph.cells) {
            if(cell.cellState == CellState.ALIVE) {
                graphView.colorCell(cell, aliveColor);
            } else {
                graphView.colorCell(cell, deadColor);
            }
        }
    }

    private void showColor() {
        showColor(graphView);
    }
}
