using Godot;
using System;

namespace Game
{
    public class Example : KinematicBody2D
    {
        int fall_speed = 1;
        private ulong PlayerCollisionId = 1276;
        private KinematicBody2D Playerok = new Player();
        public static Vector2 _screenSize;
        static Vector2 vel = new Vector2();
        int cor_x = GetRandom(Convert.ToInt32(_screenSize.x));


        static int GetRandom(int x)
        {
            Random rnd = new Random();
            int value = rnd.Next(x);
            return value;
        }

        public override void _Ready()
        {
            this.Position += new Vector2(cor_x, 0);
            _screenSize = GetViewport().Size;
        }

        public void Check(float delta)
        {   
            var collisionInfo = MoveAndCollide(vel * delta);
            if (collisionInfo != null)
            {
                QueueFree();
                Player.points += 1;
                GD.Print(Player.points);
                GD.Print(collisionInfo.ColliderId);
                // ColliderId 1276
            }

            if (this.Position.y > _screenSize.y + 50)
            {
                GD.Print("im out of bounds");
                QueueFree();
            }
        }

        public override void _PhysicsProcess(float delta)
        {
            _screenSize = GetViewport().Size;
            this.Position += new Vector2(0, fall_speed);
            if (this.Position.y >= 700)
            {
                QueueFree();
            }

            Check(delta);
        }
    }
}