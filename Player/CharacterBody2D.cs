using Godot;
using System;

public partial class CharacterBody2D : Godot.CharacterBody2D
{
	private const float Speed = 300.0f;
	
	// public const float JumpVelocity = -400.0f;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	// public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();


	


	public override void _Ready(){

	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");

		// Update player velocity
		if (direction != Vector2.Zero) {
			velocity.X = direction.X * Speed;
			velocity.Y = direction.Y * Speed;
		} else {
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			velocity.Y = Mathf.MoveToward(Velocity.Y, 0, Speed);
		}

		// Update player rotation
		LookAt(GetGlobalMousePosition());

		Velocity = velocity;
		MoveAndSlide();
	}


	// Initial gun functionality
	public override void _Input(InputEvent @event)
	{
        if (@event is InputEventMouseButton eventMouseButton)
		{
			if(eventMouseButton.Pressed && eventMouseButton.ButtonIndex.Equals(MouseButton.Left))
			{

				string path = "res://Bullet/Bullet.tscn";
				PackedScene scene = ResourceLoader.Load<PackedScene>(path) as PackedScene;
				Node2D bulletScene = scene.Instantiate() as Node2D;
				Bullet bullet = (Bullet) bulletScene.GetNode("Bullet");
				Node2D bulletSpawn = (Node2D) GetNode("BulletSpawn");
				
				bullet.Instantiate(GetGlobalMousePosition(), bulletSpawn.GlobalPosition);

				GetParent().GetParent().CallDeferred("add_child", bulletScene);

			
			}

        }
    }
	
}
