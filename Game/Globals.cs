using Godot;

public partial class Globals : Node2D
{
	public CharacterBody2D player {set; get;}
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

		GD.Print("Globals Loaded");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
