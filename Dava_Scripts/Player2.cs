using Godot;
using System;

public class Player2 : KinematicBody2D {
	int speed = 500;
	//public override void _Ready() {}
	public override void _UnhandledInput(InputEvent @event) {
	if (@event is InputEventKey eventKey)
		if (eventKey.Pressed && eventKey.Scancode == (int)KeyList.Escape){
            GetTree().Quit();
            GD.Print("Buy");
        }
	}

   // public void GetInput(){}
	
	public override void _PhysicsProcess(float delta) {	
        Vector2 vel = new Vector2();
        vel.x = Input.GetActionStrength("right") - Input.GetActionStrength("left");
        vel.y = Input.GetActionStrength("down") - Input.GetActionStrength("up");

        MoveAndCollide(vel.Normalized() * speed * delta);

        Sprite sprite = (Sprite)GetNode("Player");  
        sprite.FlipH = true;
        /*
        if (Input.IsActionPressed("right")) {
            this.Position += new Vector2(speed, 0);
        }
        if (Input.IsActionPressed("left")) {
            this.Position += new Vector2(-speed, 0);
		}
       */
    }



  // Called every frame. 'delta' is the elapsed time since the previous frame.
 // public override void _Process(float delta){}
}
