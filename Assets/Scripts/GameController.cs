using UnityEngine;

public class GameController : MonoBehaviour {
    public MapData mapData;
    public Graph graph;
    public Tick tick;

    public float timeStep = 0.1f;
    
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

            if (tick != null) {
                tick.init(graph, graphView);
                tick.StartCoroutine(tick.tickRoutine(timeStep));
            } else {
                Debug.Log("Tick is not attached to GameController");
            }
        } else {
            Debug.Log("MapData or Graph is not attached to GameController");
        }
    }
}
