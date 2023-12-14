using Godot;
using System;
using System.Reflection;

public partial class ResourceNode : StaticBody2D
{
    [Export]
    public int StartingResources { get; set; } = 1;
    [Export]
    public ResourceNodeType[] ResourceNodeTypes { get; set; }

    [Export]
    public PackedScene PickupType { get; set; }
    [Export]
    public float LaunchSpeed { get; set; } = 100.0f;
    [Export]
    public float LaunchTime { get; set; } = 0.25f;

    [Export]
    public PackedScene DepletedEffect { get; set; }
    private int _currentResources { get; set; }
    private Node _levelParent { get; set; }

    public int CurrentResources { 
        get { return _currentResources; }
        set 
        { 
            if (value <= 0) 
            { 
                QueueFree();
                var effectInstance = DepletedEffect.Instantiate() as GpuParticles2D;
                effectInstance.Position = Position;
                _levelParent.AddChild(effectInstance);
                effectInstance.Emitting = true;
            } else 
            { 
                _currentResources = value; 
            } 
        } 
    
    }
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _levelParent = GetParent();
        CurrentResources = StartingResources;

    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }

    public void Harvest(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            SpawnResources();
        }
        CurrentResources -= amount;
    }

    public void SpawnResources()
    {
        var pickupInstance = PickupType.Instantiate() as Pickup;
        _levelParent.AddChild(pickupInstance);
        pickupInstance.Position = this.Position;
        var direction = new Vector2((float)GD.RandRange(-1.0f, 1.0f), (float)GD.RandRange(-1.0f, 1.0f)).Normalized();
        pickupInstance.Launch(direction * LaunchSpeed, LaunchTime);
    }
}
