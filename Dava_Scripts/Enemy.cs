using Godot;
using System;

public class Enemy : KinematicBody2D {
	int fall_speed = 1;
<<<<<<< HEAD
    static Vector2 vel = new Vector2();
    int cor_x = GetRandom(1024);
    Sprite spr;

    Node main;

    CollisionShape2D colis;

    static int GetRandom(int x) {
        //Создание объекта для генерации чисел (с указанием начального значения)
        Random rnd = new Random();

        //Получить случайное число 
        int value = rnd.Next(x);
=======
	static Vector2 vel = new Vector2();
	

	int cor_x = GetRandom(1024);
	Sprite spr;

	static int GetRandom(int x) {
		//Создание объекта для генерации чисел (с указанием начального значения)
		Random rnd = new Random();
 
		//Получить случайное число 
		int value = rnd.Next(x);
>>>>>>> 9ec78475a2dfe95c3df074c3bb947bc112e98df9
 
		//Вернуть полученное значение
		return value;
	}

<<<<<<< HEAD
    public override void _Ready() {
        this.Position += new Vector2(cor_x, 0);
        spr = GetNode("/root/Main/Enemy/Enemy") as Sprite;
        colis = GetNode("/root/Main/Enemy/CollisionShape2D") as CollisionShape2D;
        main = GetNode("/root/Main") as Node;
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
        this.Position += new Vector2(0, fall_speed);
        Check(delta);
        //MoveAndCollide(vel.Normalized() * fall_speed * delta);
    }
=======
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
>>>>>>> 9ec78475a2dfe95c3df074c3bb947bc112e98df9

}
