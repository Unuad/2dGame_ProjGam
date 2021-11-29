using Godot;
using System;

public class Player : KinematicBody2D {
	int move_speed = 5;
    public static Vector2 _screenSize;
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
        _screenSize = GetViewport().Size;
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
        if (this.Position.x >= _screenSize.x) {
            this.Position = new Vector2(_screenSize.x, 50);
        }
    }

	public override void _PhysicsProcess(float delta) {	
        Animate();
        Check();
    }

}
