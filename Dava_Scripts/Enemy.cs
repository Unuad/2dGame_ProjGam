using Godot;
using System;

public class Enemy : KinematicBody2D {
	int fall_speed = 1;

    public static Vector2 _screenSize;
    static Vector2 vel = new Vector2();
    int cor_x = GetRandom(Convert.ToInt32(_screenSize.x));
    Sprite spr;
    Node main;
    CollisionShape2D colis;

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
        colis = GetNode("/root/Main/Enemy/CollisionShape2D") as CollisionShape2D;
        _screenSize = GetViewport().Size;
    }

    public void Check(float delta) {
        if (this.Position.y >= 560){
            QueueFree();
        }
        var collisionInfo = MoveAndCollide(vel * delta);
        if (collisionInfo != null) {
            //main.points += 1;
            QueueFree();
        }
    }
	
	public override void _PhysicsProcess(float delta) {	
        _screenSize = GetViewport().Size;
		this.Position += new Vector2(0, fall_speed);
		if (this.Position.y >= 560){
			QueueFree();
		}   
        Check(delta);
	}

}
