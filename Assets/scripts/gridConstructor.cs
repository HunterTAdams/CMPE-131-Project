using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class gridConstructor : MonoBehaviour
{
    public Tilemap tilemap;
    public int minxdimension;
    public int minydimension;
    public int maxxdimension;
    public int maxydimesnion;
    public GameObject tile;
    public GameObject[] enableatstart = new GameObject[10];
    public zonescript firstzone;
    // Construct the grid and add each tile, by its coordinates, into tileaccess.tileDict. go through tilemap using HasTile and a huge box incapsulating the world. this can be inefficeint. once its done set the tilemap SetActive(false)
    void Start()
    {
        tileaccess.tileDict = new Dictionary<Vector2Int, tileScript>();
        tileaccess.energy = 0;

        for (int x = minxdimension; x < maxxdimension; x++)
        {
            for (int y = minydimension; y < maxxdimension; y++)
            {
                
                Vector3Int position = new Vector3Int(x, y, 0);
                if (tilemap.HasTile(position))
                {
                    GameObject newTile = Instantiate(tile, this.transform);
                    newTile.transform.position = tilemap.GetCellCenterWorld(position);
                    tileScript newTileScript = (tileScript)newTile.GetComponent("tileScript");
                    newTileScript.position = new Vector2Int(x, y);
                    tileaccess.tileDict.Add(newTileScript.position, newTileScript);

                }
            }
        }
        tilemap.ClearAllTiles();
        tileaccess.currentzone = firstzone;
        foreach (GameObject i in enableatstart)
        {
            i.SetActive(true);//ayyyyyy easiest way to make shit spawn at the start w/o worrying about the dictionary bein there
        }
        

    }
}
