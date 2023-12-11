using Godot;
using System;

public partial class Player : CharacterBody2D
{
	[Export]
	public float Speed = 100.0f;

    public AnimationTree AnimationTree { get; set; }
	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public Vector2 Direction { get; set; } = Vector2.Zero;
    public override void _Ready()
    {
		AnimationTree = GetNode<AnimationTree>("AnimationTree");
		AnimationTree.Active = true;
    }

    public override void _Process(double delta)
    {
		UpdateAnimationParams();
    }
    public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

        // Get the input direction and handle the movement/deceleration.
        // As good practice, you should replace UI actions with custom gameplay actions.
        Direction = Input.GetVector("left", "right", "up", "down").Normalized();
		if (Direction != Vector2.Zero)
		{
			velocity = Direction * Speed;
		}
		else
		{
			velocity = Vector2.Zero;
		}

		Velocity = velocity;
		MoveAndSlide();
	}

	private void UpdateAnimationParams()
	{
		if(Velocity == Vector2.Zero)
		{
            AnimationTree.Set("parameters/conditions/idle", true);
            AnimationTree.Set("parameters/conditions/is_moving", false);

        }
		else
		{
            AnimationTree.Set("parameters/conditions/idle", false);
            AnimationTree.Set("parameters/conditions/is_moving", true);
        }

		if(Input.IsActionJustPressed("use"))
		{
            AnimationTree.Set("parameters/conditions/swing", true);
        }
		else
		{
            AnimationTree.Set("parameters/conditions/swing", false);
        }

		if(Direction != Vector2.Zero)
		{
            AnimationTree.Set("parameters/Idle/blend_position", Direction);
            AnimationTree.Set("parameters/Swing/blend_position", Direction);
            AnimationTree.Set("parameters/Walk/blend_position", Direction);
        }
    }
}
