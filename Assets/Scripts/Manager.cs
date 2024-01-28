using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Manager : MonoBehaviour
{

    public GameObject pipePrefabs;
    public List<GameObject> singlePipe;
    public int gridHeight;
    public int gridDepth;
    public int gridWidth;
    private Grid grid;
    private Tile currentTile;
    // Start is called before the first frame update
    void Start()
    {
        InitializeGrid();
    }
    public void Update()
    {
        AddPipeSegment();
    }
    void InitializeGrid()
    {
        grid = new Grid(gridWidth, gridHeight, gridDepth);
        InitializePipe();


    }

   
   void InitializePipe()
    {
        currentTile = grid.GetRandomGridPoint();
        if (currentTile.isOccupied==false) { 
        singlePipe.Add(Instantiate(pipePrefab,new Vector3(currentTile.X, currentTile.Y, currentTile.Z),Quaternion.identity));
    
        }
    }
    void InitializePipe(Tile tile)
    {
        
       singlePipe.Add(Instantiate(pipePrefab,new Vector3(tile.X,tile.Y, tile.Z),Quaternion.identity));
    }

    void AddPipeSegment()
    {

        Tile next = grid.GetRandomFreeNeighbor(currentTile);
        if (next != null) 
        {  
        InitializePipe(next);
        next.isOccupied = true;
        currentTile = next;
        }
        else
        {
            //InitializePipe();
        }
    }
    

}