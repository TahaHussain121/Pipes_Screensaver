using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile { 
    public int X;
    public int Y;
    public int Z;
    public bool isOccupied;

  //  public List<Tile> neighbours;

    public Tile(int x, int y, int z, bool isoccupied)
    {
        X = x;
        Y = y;
        Z = z;

        isOccupied = isoccupied;
    }


}

