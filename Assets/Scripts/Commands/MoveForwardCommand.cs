using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForwardCommand : ICommand
{
    public Transform player;
    private float speed;

    public MoveForwardCommand(Transform player, float speed)
    {
        this.player = player;
        this.speed = speed;
    }
    public void Execute()
    {
        player.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    public void Undo()
    {
        player.Translate(Vector3.back * speed * Time.deltaTime);
    }
}
