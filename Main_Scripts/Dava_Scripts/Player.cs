using Godot;
using System;

public class Player : KinematicBody2D
{
    public int speed = 5;

    public void GetInput(){

        if (Input.IsActionPressed("right"))
            this.Position += new Vector2(speed, 0);

        if (Input.IsActionPressed("left"))
            this.Position += new Vector2(-speed, 0);

        if (Input.IsActionPressed("down"))
            this.Position += new Vector2(0, speed);

        if (Input.IsActionPressed("up"))
            this.Position += new Vector2(0, -speed);

    }

    public override void _PhysicsProcess(float delta){
        GetInput();
    }
}