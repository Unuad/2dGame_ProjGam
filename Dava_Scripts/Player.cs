using Godot;
using System;

public class Player : KinematicBody2D {
	int move_speed = 5;
    int screen_size_x = 1024;
    private AnimatedSprite _animatedSprite;

    public override void _UnhandledInput(InputEvent @event) {
	if (@event is InputEventKey eventKey)
		if (eventKey.Pressed && eventKey.Scancode == (int)KeyList.Escape){
            GetTree().Quit();
            GD.Print("Buy");
        }
	}
    public override void _Ready() {
        _animatedSprite = GetNode<AnimatedSprite>("/root/Main/Player/Player");
        this.Position += new Vector2(100, 0);
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
            _animatedSprite.Play("idle");
        }
    }
	
    public void Check() {
        if (this.Position.x < 0) {
            this.Position = new Vector2(0, 50);
        }
        if (this.Position.x >= screen_size_x) {
            this.Position = new Vector2(screen_size_x, 50);
        }
    }

	public override void _PhysicsProcess(float delta) {	
        Animate();
        Check();
    }

}
