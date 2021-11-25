using Godot;
using System;

public class Player : KinematicBody2D {
	int move_speed = 5;
    static Vector2 vel = new Vector2();
   
    private AnimatedSprite _animatedSprite;

    string side = "left";

    public override void _UnhandledInput(InputEvent @event) {
	if (@event is InputEventKey eventKey)
		if (eventKey.Pressed && eventKey.Scancode == (int)KeyList.Escape){
            GetTree().Quit();
            GD.Print("Buy");
        }
	}
    public override void _Ready() {
        _animatedSprite = GetNode<AnimatedSprite>("/root/Main/Player/Player");
    }

    public void Animate(){
        if (Input.IsActionPressed("right")) {
            this.Position += new Vector2(move_speed, 0);
            _animatedSprite.Play("run");
            _animatedSprite.FlipH = true;
        }else if (Input.IsActionPressed("left")) {
            this.Position += new Vector2(-move_speed, 0);
            _animatedSprite.Play("run");
            _animatedSprite.FlipH = false;
		}
        else {
            _animatedSprite.Stop();
            _animatedSprite.Play("idle");
        }
    }
	
	public override void _PhysicsProcess(float delta) {	
        
        Animate();
        /*if (Input.IsActionPressed("right")) {
            this.Position += new Vector2(move_speed, 0);
            side = "right";
        }
        if (Input.IsActionPressed("left")) {
            this.Position += new Vector2(-move_speed, 0);
            side = "left";
		}
        var pick = GetNode("/root/Main/Player/Player") as Sprite;

        switch (side)
        {
            case "left":
                pick.FlipH = false;
                break;
            default:
                pick.FlipH = true;
                break;
        } */

    }

}
