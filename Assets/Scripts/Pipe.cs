using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public Renderer pipeRenderer;
    private Color pipeColor;
   
    public void AssignColor(Color color)
    {
        pipeRenderer.material.color = color;   
    
    }
}
