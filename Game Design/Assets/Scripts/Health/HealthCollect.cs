using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps; //

public class HealthCollect : MonoBehaviour
{
    [SerializeField] private Tilemap heartsTilemap;
    private float healthValue = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Health>().AddHealth(healthValue); // Heal the player
        }

        if (heartsTilemap != null)
        {
            Vector3Int cellPosition = heartsTilemap.WorldToCell(collision.transform.position);
            TileBase tile = heartsTilemap.GetTile(cellPosition);
            if (tile != null)
            {
                heartsTilemap.SetTile(cellPosition, null); // Remove the heart tile
            }
        }
    }
}
