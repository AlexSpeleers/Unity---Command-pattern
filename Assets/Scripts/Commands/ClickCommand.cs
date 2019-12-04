using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickCommand : ICommand
{
    public GameObject cube;
    private Color color;
    private Color previousColor;
    public ClickCommand(GameObject cube, Color color)
    {
        this.cube = cube;
        this.color = color;
    }
    public void Execute()
    {
        previousColor = cube.GetComponent<MeshRenderer>().material.color;
        cube.GetComponent<MeshRenderer>().material.color = color;
    }

    public void Undo()
    {
        cube.GetComponent<MeshRenderer>().material.color = previousColor;
    }   
}
