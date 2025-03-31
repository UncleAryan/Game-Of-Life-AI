using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour {
    public MapData mapData;
    public Graph graph;
    
    void Start() {
        if(mapData != null && graph != null) {
            int[,] mapInstance = mapData.makeMap();
            graph.init(mapInstance);

            GraphView graphView = graph.GetComponent<GraphView>();
            if(graphView != null) {
                graphView.init(graph);
            } else {
                Debug.Log("GraphView is not attached to Graph");
            }
        } else {
            Debug.Log("MapData or Graph is not attached to GameController");
        }
    }
}
