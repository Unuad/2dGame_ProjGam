using Godot;
using System;

namespace Game
{
    public class Main : Node2D
    { 
        public static Vector2 _screenSize; 
        private int cor_x;
        private static PackedScene Apple = ResourceLoader.Load<PackedScene>("res://Scenes/Apple.tscn");
        private static PackedScene Dumbbell = ResourceLoader.Load<PackedScene>("res://Scenes/Dumbbell.tscn");
        private static PackedScene Book = ResourceLoader.Load<PackedScene>("res://Scenes/Book.tscn");
        private static PackedScene Banana = ResourceLoader.Load<PackedScene>("res://Scenes/Banana.tscn");
        private static PackedScene Cigarette = ResourceLoader.Load<PackedScene>("res://Scenes/Cigarette.tscn");
        private static PackedScene Beer = ResourceLoader.Load<PackedScene>("res://Scenes/Beer.tscn");
        private static PackedScene Tiktok = ResourceLoader.Load<PackedScene>("res://Scenes/Tiktok.tscn");
        private static PackedScene Gamburger = ResourceLoader.Load<PackedScene>("res://Scenes/Gamburger.tscn");

        private PackedScene[] all_stuff = new PackedScene[8] {Apple, Dumbbell, Book, Banana, Cigarette, Beer, Tiktok, Gamburger};
        
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
            timer.WaitTime = 1;
            timer.Connect("timeout", this, "Spawn");
            timer.Start();
        }

        public void Spawn()
        {
            Godot.KinematicBody2D thing = all_stuff[GetRandom(7)].Instance() as KinematicBody2D;
            AddChild(thing);
            //GD.Print("Im alive");
        }

    }
}