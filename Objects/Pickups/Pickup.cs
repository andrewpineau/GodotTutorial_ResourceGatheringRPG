using Godot;
using System;

[GlobalClass]
public partial class Pickup : Area2D
{
    public CollisionShape2D CollisionShape { get; set; }
    [Export]
    public Resource ResourceType { get; set; }
    public Vector2 LaunchVelocity { get; set; } = Vector2.Zero;
    public float MoveDuration { get; set; } = 0;
    public float TimeSinceLaunch { get; set; } = 0;
    private bool _isLaunching;
    public bool IsLaunching { 
        get { return _isLaunching; } 
        set { 
            _isLaunching = value;
            CollisionShape.Disabled = value;
        } 
    }
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
        CollisionShape = GetNode<CollisionShape2D>("CollisionShape2D");
        BodyEntered += OnBodyEntered;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
        if (IsLaunching)
        {
            Position += (LaunchVelocity * (float)delta);
            TimeSinceLaunch += (float)delta;

            if (TimeSinceLaunch >= MoveDuration)
            {
                IsLaunching = false;
            }
        }
	}

    public void Launch(Vector2 velocity, float moveDuration)
    {
        LaunchVelocity = velocity;
        TimeSinceLaunch = 0;
        IsLaunching = true;
        MoveDuration = moveDuration;
    }

    public void OnBodyEntered(Node2D body)
    {
        var inventory = body.FindChild("Inventory") as Inventory;
        if(inventory != null)
        {
            inventory.AddResources(ResourceType, 1);
            QueueFree();
        }
    }
}
