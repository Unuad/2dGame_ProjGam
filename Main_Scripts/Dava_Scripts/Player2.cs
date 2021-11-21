using Godot;
using System;

public class Player2 : KinematicBody2D {
	int speed = 5;
	//int gravity = 400;
	//int jumpForce = 500;

    //public Vector2 vel = new Vector2();

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
        
        if (Input.IsActionPressed("right")) {
            this.Position += new Vector2(speed, 0);
            //vel.x += speed;
            //this.Position += vel;
        }
        if (Input.IsActionPressed("left")) {
            this.Position += new Vector2(-speed, 0);
            //vel.x -= -speed;
            //this.Position += vel;
		}
        
        //vel = vel.Normalized() * speed;
       
    }



  // Called every frame. 'delta' is the elapsed time since the previous frame.
 // public override void _Process(float delta){}
}
