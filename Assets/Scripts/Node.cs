using System.Collections.Generic;
using UnityEngine;

public enum NodeType {
    ALIVE = 1, DEAD = 0
}

public class Node {
    public NodeType nodeType = NodeType.ALIVE;
    public int xIndex = -1;
    public int yIndex = -1;
    public Vector3 position;
    public List<Node> neighbors = new List<Node>();
    public Node previous = null;

    public Node(int xIndex, int yIndex, NodeType nodeType) {
        this.xIndex = xIndex;
        this.yIndex = yIndex;
        this.nodeType = nodeType;
    }

    public void reset() {
        previous = null;
    }
}

