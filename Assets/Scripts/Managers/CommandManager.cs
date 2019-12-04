using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CommandManager : MonoSingleton<CommandManager>
{
    private List<ICommand> commandBuffer = new List<ICommand>();

    public void AddCommand(ICommand command)
    {
        commandBuffer.Add(command);
    }

    public void Play()
    {
        StartCoroutine(PlayRoutine());
    }
    IEnumerator PlayRoutine()
    {
        Debug.Log("Playing!");
        foreach (var command in commandBuffer)
        {
            command.Execute();
            yield return new WaitForEndOfFrame();
        }
        Debug.Log("Finished!");
    }

    public void Rewind()
    {
        StartCoroutine(RewindRoutine());
    }
    IEnumerator RewindRoutine()
    {
        foreach (var command in Enumerable.Reverse(commandBuffer))
        {
            command.Undo();
            yield return new WaitForEndOfFrame();
        }
    }

    public void Done()
    {
        StopAllCoroutines();
        var cubes = GameObject.FindGameObjectsWithTag("Cube");
        foreach (var cube in cubes)
        {
            cube.GetComponent<MeshRenderer>().material.color = Color.white;
        }
    }

    public void Reset()
    {
        commandBuffer.Clear();
    }
}
