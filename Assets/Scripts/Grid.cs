using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Grid 
{
    [SerializeField]private int gridHeight;
    [SerializeField] private int gridDepth;
    [SerializeField] private int gridWidth;
    List<Tile> tileList = new List<Tile>();
    public Grid(int x, int y, int z)
    {    gridDepth = z;
         gridHeight = y;
         gridWidth = x;

        InitializeTiles();


    }

    public void InitializeTiles()
    {
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                for (int z = 0; z < gridDepth; z++)
                {
                            tileList.Add(new Tile(x, y, z, false));

                    
                }
            }

        }
    }


    public Tile GetRandomGridPoint()
    {
        int x = Random.Range(0, gridWidth);
        int y = Random.Range(0, gridHeight);
        int z = Random.Range(0, gridDepth);

        return tileList.FirstOrDefault(tile => tile.X == x && tile.Y == y && tile.Z == z);
    }

    bool IsWithinGrid(int x, int y, int z)
    {
        return x >= 0 && x < gridWidth && y >= 0 && y < gridHeight && z >= 0 && z < gridDepth;
    }

    public Tile GetRandomFreeNeighbor(Tile tile)
    {
        List<Tile> freeNeighbors = new List<Tile>();
        int[] dx = { 1, -1, 0, 0, 0, 0 };
        int[] dy = { 0, 0, 1, -1, 0, 0 };
        int[] dz = { 0, 0, 0, 0, 1, -1 };

        for (int direction = 0; direction < 6; direction++)
        {
            int newX = tile.X + dx[direction];
            int newY = tile.Y + dy[direction];
            int newZ = tile.Z + dz[direction];

            if (IsWithinGrid(newX, newY, newZ))
            {
                Tile neighbor = tileList.FirstOrDefault(t => t.X == newX && t.Y == newY && t.Z == newZ);
                if (neighbor != null && !neighbor.isOccupied) // Check if the neighbor is free
                    freeNeighbors.Add(neighbor);
            }
        }

        if (freeNeighbors.Count > 0)
        {
            int randomIndex = Random.Range(0, freeNeighbors.Count);
            return freeNeighbors[randomIndex];
        }

        return null; // Return null if no free neighbor is found
    }



}
