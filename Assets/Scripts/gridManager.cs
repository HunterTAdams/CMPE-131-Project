//forgive my code my visualstudio is fubar
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class gridManager: MonoBehaviour
{
    //singleton
    public static gridManager Instance { get; private set; }
    public Tilemap tilemap;
    public GameObject tileprefab;
    public GameObject container;
    Dictionary<Vector2, GameObject> tilelist;
    public Grid parentGrid;

    //enforce singleton
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        
    }

    //constructs active objects at any positions where the tilemap has a sprite. creates a dictionary of them.
    void Start()
    {
        
        tilelist = new Dictionary<Vector2, GameObject>();
        BoundsInt bounds = tilemap.cellBounds;
        for (int y =bounds.min.y; y < bounds.max.y; y++)
        {
            for (int x =bounds.min.x; x < bounds.max.x; x++)
            {
                Vector3Int tileLocation = new Vector3Int(x, y, 0); //if we need to raise the prefab to appear over the background tile, change that zero. If we want a 3rd dimension, nest another for loop for z.
                if (tilemap.HasTile(tileLocation))
                {
                    tilelist.Add(new Vector2(tileLocation.x, tileLocation.y), Instantiate(tileprefab, tilemap.GetCellCenterWorld(tileLocation), Quaternion.identity, container.transform));
                }
            }
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
