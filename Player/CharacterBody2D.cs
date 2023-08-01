using Godot;
using System;

public partial class CharacterBody2D : Godot.CharacterBody2D
{
	public const float Speed = 300.0f;
	// public const float JumpVelocity = -400.0f;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	// public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();


	private AnimationPlayer animationPlayer;
	private AnimatedSprite2D animatedSprite2D;

	private String idleDirection;


	public override void _Ready(){
		animationPlayer = (AnimationPlayer) GetNode("AnimationPlayer");
		animatedSprite2D = (AnimatedSprite2D) GetNode("AnimatedSprite2D");
		idleDirection = "Idle_Down";
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");

		if(direction.X == 1 && animatedSprite2D.FlipH == false) {
			animatedSprite2D.FlipH = true;
		} else if(direction.X == -1 && animatedSprite2D.FlipH == true) {
			animatedSprite2D.FlipH = false;
		}

		if (direction != Vector2.Zero) {
			velocity.X = direction.X * Speed;
			velocity.Y = direction.Y * Speed;

			if(direction.X != 0) {
				idleDirection = "Idle_Left";
				animationPlayer.Play("Walk_Left");

			} else if (direction.Y != 0) {
				idleDirection = "Idle_Down";
				animationPlayer.Play("Walk_Down");	

			}



		} else {
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			velocity.Y = Mathf.MoveToward(Velocity.Y, 0, Speed);
			animationPlayer.Play(idleDirection);
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
