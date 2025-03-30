using UnityEngine;

public class CellView: MonoBehaviour {
    public GameObject tile;
    [Range(0, 0.5f)]
    public float borderSize = 0.15f;

    public void init(Cell cell) {
        if (tile != null) {
            tile.name = "Node (" + cell.position.x + ", " + cell.position.z + ")";
            tile.transform.position = cell.position;
            tile.transform.localScale = new Vector3(1f - borderSize, 1f, 1f - borderSize);
        }
    }

    private void colorNode(Color color, GameObject gameObject) {
        if (gameObject != null) {
            Renderer gameObjectRenderer = gameObject.GetComponent<Renderer>();
            gameObjectRenderer.material.color = color;
        }
    }

    public void colorNode(Color color) {
        colorNode(color, tile);
    }
}
