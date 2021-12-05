using Godot;
using System;
using System.Collections.Generic;

namespace Game
{
    public class Player : KinematicBody2D
    {
        int move_speed = 5;
        public static Vector2 _screenSize;
        private AnimatedSprite _animatedSprite;
        public static int points = 0;
        public override void _UnhandledInput(InputEvent @event)
        {
            if (@event is InputEventKey eventKey)
                if (eventKey.Pressed && eventKey.Scancode == (int) KeyList.Escape)
                {
                    GetTree().Quit();
                    GD.Print("Buy");
                }
        }

        public override void _Ready()
        {
            _animatedSprite = GetNode<AnimatedSprite>("/root/Main/Player/Player");
            this.Position += new Vector2(100, 0);
            _screenSize = GetViewport().Size;
        }

        public void Spawn()
        {
            GD.Print("im spawner");
        }
        
        public void Animate()
        { /* Animating Sprite */
            if (Input.IsActionPressed("right"))
            {
                this.Position += new Vector2(move_speed, 0);
                _animatedSprite.Play("run");
                _animatedSprite.FlipH = true;
            }
            else if (Input.IsActionPressed("left"))
            {
                this.Position += new Vector2(-move_speed, 0);
                _animatedSprite.Play("run");
                _animatedSprite.FlipH = false;
            }
            else
            {
                _animatedSprite.Play("idle");
            }
        }

        public void Check()
        {  /* Checking posithion of player and dont let him go out of bounds */
            Position = new Vector2(
                x: Mathf.Clamp(Position.x, 0 + 64, _screenSize.x - 64),
                y: Mathf.Clamp(Position.y, 0, _screenSize.y)
            );
        }

        public override void _PhysicsProcess(float delta)
        {
            _screenSize = GetViewport().Size;
            Animate();
            Check();
        }
    }
}