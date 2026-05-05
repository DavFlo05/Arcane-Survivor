using UnityEngine;

public class InfiniteMap : MonoBehaviour
{
    public Transform player;
    public GameObject tilePrefab;
    public int gridSize = 3;
    public float tileSize = 20f;

    private GameObject[,] tiles;
    private Vector2Int currentPlayerTile;

    void Start()
    {
        tiles = new GameObject[gridSize, gridSize];

        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                Vector3 position = new Vector3(
                    (x - 1) * tileSize,
                    (y - 1) * tileSize,
                    0
                );

                tiles[x, y] = Instantiate(tilePrefab, position, Quaternion.identity);
            }
        }
    }

    void Update()
    {
        Vector2Int playerTile = new Vector2Int(
            Mathf.FloorToInt(player.position.x / tileSize),
            Mathf.FloorToInt(player.position.y / tileSize)
        );

        if (playerTile != currentPlayerTile)
        {
            currentPlayerTile = playerTile;
            RepositionTiles();
        }
    }

    void RepositionTiles()
    {
        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                int offsetX = x - 1;
                int offsetY = y - 1;

                Vector3 newPosition = new Vector3(
                    (currentPlayerTile.x + offsetX) * tileSize,
                    (currentPlayerTile.y + offsetY) * tileSize,
                    0
                );

                tiles[x, y].transform.position = newPosition;
            }
        }
    }
}
