using Godot;
using Godot.Collections;
using System;

public partial class Inventory : Node
{
	[Signal]
	public delegate void ResourceCountChangedEventHandler(ResourceItem type, int newCount);
	[Export]
    public Dictionary<Resource, int> Resources { get; set; } = new Dictionary<Resource, int>();
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void AddResources(Resource type, int amount)
	{
        if (Resources.ContainsKey(type))
		{
			Resources[type] += amount;
        }
		else
		{
			Resources.Add(type, amount);
		}

		EmitSignal(SignalName.ResourceCountChanged, type, Resources[type]);
	}
}
