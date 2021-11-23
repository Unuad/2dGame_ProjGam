using Godot;
using System;

public class Player : KinematicBody2D {
	int move_speed = 500;
    static Vector2 vel = new Vector2();
	public override void _UnhandledInput(InputEvent @event) {
	if (@event is InputEventKey eventKey)
		if (eventKey.Pressed && eventKey.Scancode == (int)KeyList.Escape){
            GetTree().Quit();
            GD.Print("Buy");
        }
	}

   // public void GetInput(){}
	
	public override void _PhysicsProcess(float delta) {	
        
        vel.x = Input.GetActionStrength("right") - Input.GetActionStrength("left");
        vel.y = Input.GetActionStrength("down") - Input.GetActionStrength("up");
        MoveAndCollide(vel.Normalized() * move_speed * delta);
        Image pick = new Image();
        pick.FlipX();
    }

}
