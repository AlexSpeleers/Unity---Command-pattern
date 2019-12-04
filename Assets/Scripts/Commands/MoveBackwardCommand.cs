using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackwardCommand : ICommand
{
    public Transform player;
    private float speed;

    public MoveBackwardCommand(Transform player, float speed)
    {
        this.player = player;
        this.speed = speed;
    }
    public void Execute()
    {
        player.Translate(Vector3.back * speed * Time.deltaTime);
    }

    public void Undo()
    {
        player.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
