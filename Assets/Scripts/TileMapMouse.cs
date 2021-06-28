using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TileMap))]
public class TileMapMouse : MonoBehaviour
{
    TileMap _tileMap;

    Vector3 currentTileCoord;

    public Transform selectionCube;

    private void Start()
    {
        _tileMap = GetComponent<TileMap>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        MeshCollider collider = GetComponent<MeshCollider>();

        if (collider.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity))
        {
            int x = Mathf.FloorToInt(hitInfo.point.x / _tileMap.tileSize);
            int z = Mathf.FloorToInt(hitInfo.point.z / _tileMap.tileSize);

            currentTileCoord.x = x;
            currentTileCoord.z = z;

            selectionCube.transform.position = currentTileCoord * 5f;
        }
        else
        {
            
        }
    }
}
