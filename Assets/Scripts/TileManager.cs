using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    [SerializeField]
    private GameObject tilePrefab;

    [SerializeField]
    private Transform playerTransform;

    private float spawnZ = 0.0f;
    private float tileLength = 10.0f;
    private int amnTilesOnScreen = 3;

    [SerializeField]
    private List<GameObject> activeTiles = new List<GameObject>();
    [SerializeField]
    private List<GameObject> deactiveTiles = new List<GameObject>();

    private void Start()
    {
        SpawnTile();
    }

    void Update()
    {
        if (playerTransform.position.z - amnTilesOnScreen * tileLength - tileLength < spawnZ - amnTilesOnScreen * tileLength)
        {
            SpawnTile();
        }
    }

    /// <summary>
    /// 타일 생성 함수
    /// </summary>
    private void SpawnTile()
    {
        GameObject tile;

        if (activeTiles.Count > amnTilesOnScreen)
        {
            tile = activeTiles[0];
            activeTiles.RemoveAt(0);
        }
        else
        {
            tile = Instantiate(tilePrefab);
            tile.transform.SetParent(transform);
        }
        activeTiles.Add(tile);
        tile.transform.position = Vector3.forward * spawnZ;
        spawnZ -= tileLength;
    }
}
