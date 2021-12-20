using Godot;
using System;
namespace Game
{
	public class outpoints : Label
	{
		public override void _Ready()
		{
			this.SetText(Convert.ToString(Player.points));
			//this.GetLineHeight(100);
		}

	
		public override void _Process(float delta)
		{
			this.SetText(Convert.ToString(Player.points));
		}
	}
	
}
