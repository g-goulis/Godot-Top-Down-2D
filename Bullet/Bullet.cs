using Godot;
using System;

public partial class Bullet : RigidBody2D
{
	private const float BULLET_SPEED = 100.0f;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		MaxContactsReported = 3;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void _on_body_entered(Node2D n) {
		// GD.Print("Entered!");
		QueueFree();
	}

	public void Instantiate(Vector2 mousePosition, Vector2 spawnPosition) {
		Position = spawnPosition;

		Vector2 velocity = mousePosition;
		velocity -= spawnPosition;

		GD.Print("Calculating Velocity " + spawnPosition + " -= " + mousePosition + " = " + velocity.Normalized());
		velocity = velocity.Normalized();
		velocity.X *= BULLET_SPEED;
		velocity.Y *= BULLET_SPEED;
		LinearVelocity = velocity;	

	}
}
