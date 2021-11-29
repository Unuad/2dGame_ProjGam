using Godot;
using System;

public class Enemy : KinematicBody2D {
	int fall_speed = 1;
	static Vector2 vel = new Vector2();
	

	int cor_x = GetRandom(1024);
	Sprite spr;

	static int GetRandom(int x) {
		//Создание объекта для генерации чисел (с указанием начального значения)
		Random rnd = new Random();
 
		//Получить случайное число 
		int value = rnd.Next(x);
 
		//Вернуть полученное значение
		return value;
	}

	public override void _Ready() {
		this.Position += new Vector2(cor_x, 0);
		spr = GetNode("/root/Main/Enemy/Enemy") as Sprite;
	}

	
	public override void _PhysicsProcess(float delta) {	
		   //GD.Print(cor_x);
		this.Position += new Vector2(0, fall_speed);
		if (this.Position.y >= 560){
			//GD.Print("i must be killed");
			QueueFree();
		}   
	}

}
