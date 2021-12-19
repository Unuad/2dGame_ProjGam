using Godot;
using System;
namespace Game
{
	public class outpoints : HBoxContainer
	{
		private int number_label;
		public override void _Ready()
		{
			number_label = Player.points;
		}

	
		public override void _Process(float delta)
		{
			number_label = Player.points;
		}
	}
}
