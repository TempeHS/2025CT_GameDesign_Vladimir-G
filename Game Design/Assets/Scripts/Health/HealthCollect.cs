using UnityEngine;
using UnityEngine.Tilemaps;

public class HealthCollect : MonoBehaviour
{
    [SerializeField] private Tilemap heartsTilemap;
    [SerializeField] private TileBase heartTile;
    [SerializeField] private float healthValue = 1f;

    private void Update()
    {
        Vector3 playerWorldPos = transform.position;
        Vector3Int tilePos = heartsTilemap.WorldToCell(playerWorldPos);
        TileBase tile = heartsTilemap.GetTile(tilePos);

        if (tile == heartTile)
        {
            GetComponent<Health>().AddHealth(healthValue);
            heartsTilemap.SetTile(tilePos, null); // Remove the tile
        }
    }
}
