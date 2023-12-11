using Godot;
using System;

public partial class ResourceNode : StaticBody2D
{
    [Export]
    public int StartingResources { get; set; } = 1;
    public int CurrentResources { get; set; }
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        CurrentResources = StartingResources;

    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }

}
