using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile { 
    public int X;
    public int Y;
    public int Z;
    public bool isOccupied;


    public Tile(int x, int y, int z, bool isoccupied)
    {
        X = x;
        Y = y;
        Z = z;

        isOccupied = isoccupied;
    }

    public Vector3 Position()
    {
        return new Vector3(X, Y, Z);
    }

}

