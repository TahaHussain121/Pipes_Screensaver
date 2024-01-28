using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Generator : MonoBehaviour
{

    public GameObject pipePrefab;
    public List<GameObject> pipeList;
    public int gridHeight;
    public int gridDepth;
    public int gridWidth;
    private Grid grid;
    private Tile currentTile;
    private Vector3 currentDirection =  Vector3.forward;
    private Color currentColor;
   
    void Start()
    {
        InitializeGrid();
        InvokeRepeating("AddPipeSegment", 1f, 0.05f);
    }
 
    //Initialize the grid 
    void InitializeGrid()
    {
        grid = new Grid(gridWidth, gridHeight, gridDepth);
        InitializePipe();


    }

    //Assign color to the pipe
    public void AssignColor(Pipe pipe)
    {
        currentColor = new Color
                (Random.Range(0f, 1f), // R
                Random.Range(0f, 1f), // G
                Random.Range(0f, 1f)); // B

        pipe.AssignColor(currentColor);
    }

    // initialize pipe starting
    void InitializePipe()
    {
       
        currentTile = grid.GetRandomGridPoint();
       
        if(currentTile != null) { 
      
            GameObject pipeSegment = Instantiate(pipePrefab, currentTile.Position(), Quaternion.LookRotation(currentDirection));
            AssignColor( pipeSegment.GetComponent<Pipe>());
            currentTile.isOccupied = true;
            pipeList.Add(pipeSegment);

 
        }
        else
        {
            //No free tile no turn off loop
            CancelInvoke("AddPipeSegment");

        }
    }

    // initialize pipe starting by getting the specific tile
    void InitializePipe(Tile tile)
    {

        GameObject pipeSegment = Instantiate(pipePrefab, tile.Position(), Quaternion.LookRotation(currentDirection));
        pipeSegment.GetComponent<Pipe>().AssignColor(currentColor);
        pipeList.Add(pipeSegment);
       
    }

    //pick neighbour, calculate pipes direction and then generate the new pipe part
    void AddPipeSegment()
    {

        Tile next = grid.GetRandomFreeNeighbor(currentTile);
        if (next != null) 
        {
            currentDirection = (next.Position() - currentTile.Position()).normalized;
            InitializePipe(next);
            next.isOccupied = true;
            currentTile = next;
        }
        else
        {
            InitializePipe();//initialize a totally new pipe
        }
    }
    

}