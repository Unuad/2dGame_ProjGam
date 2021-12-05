using Godot;
using System;

namespace Game
{
    public class Main : Node2D
    { 
        public static Vector2 _screenSize; 
        private int cor_x;
        private PackedScene good_stuff_scene = ResourceLoader.Load<PackedScene>("res://Scenes/Good.tscn");
        
       static int GetRandom(int x)
        {
            Random rnd = new Random();
            int value = rnd.Next(x);
            return value;
        }
        public override void _Ready()
        {
            
            _screenSize = GetViewport().Size;
            // Timer
            Timer timer = this.GetNode<Timer>("/root/Main/Clock");
            timer.WaitTime = 2;
            timer.Connect("timeout", this, "Spawn");
            timer.Start();
        }

        public void Spawn()
        {
            Godot.KinematicBody2D stuff = good_stuff_scene.Instance() as KinematicBody2D;
            AddChild(stuff);
            GD.Print("Im alive");
        }

    }
}