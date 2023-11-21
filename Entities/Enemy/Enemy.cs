using Godot;

enum State {
	SURROUND,
	ATTACK,
	HIT
};

public partial class Enemy : Godot.CharacterBody2D
{
	private const int SPEED = 30;
	// public const float Speed = 300.0f;
	private State state = State.SURROUND;
	// public const float JumpVelocity = -400.0f;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	// public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	public override void _PhysicsProcess(double delta)
	{
		switch(state) {
			case State.SURROUND:
				moveTowardPlayer((int) delta);
				break;
		}
	}

	private void moveTowardPlayer(int delta) {
		Globals g = GetNode<Globals>("/root/Globals");
		Vector2 velocity = Velocity;

		// Calculate direction towards the player
		Vector2 direction = (g.player.GlobalPosition - GlobalPosition).Normalized();

		// Calculate desired velocity
		Vector2 desiredVelocity = direction * SPEED;
		
		Velocity = desiredVelocity;
		MoveAndSlide();
		
	}
}
