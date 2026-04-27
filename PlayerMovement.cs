using Godot;
using System;

public partial class PlayerMovement : CharacterBody2D
{
	
	public float moveSpeed = 300.0f;
	public float jumpVelocity = 400.0f;
	
	// get gravity from project settings (keep everything synced)
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	
	public override void _Ready()
	{
		// get sprite references
		
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
		
		// apply gravity if in the air
		if (!IsOnFloor()) {
			velocity.Y += gravity * (float)delta;
		}
		
		// handle jump (if grounded)
		if (Input.IsActionJustPressed("jump") && IsOnFloor())
			velocity.Y = -jumpVelocity;
		
		// handle horizontal movement (keyboard arrow keys)
		float direction = Input.GetAxis("left", "right");
		velocity.X = direction * moveSpeed;
		
		
		
		Velocity = velocity;
		MoveAndSlide();
	}
	
	
	
	
}
