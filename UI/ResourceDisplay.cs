using Godot;
using System;
using System.Collections.Generic;

public partial class ResourceDisplay : MarginContainer
{
	[Export]
    public PackedScene ItemDisplayTemplate { get; set; }
    public GridContainer Grid { get; set; }
    public List<ResourceItemDisplay> ResourceItemDisplays { get; set; } = new List<ResourceItemDisplay>(); 
    public Inventory PlayerInventory { get; set; }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
        Grid = GetNode<GridContainer>("Grid");
        var player = GetTree().GetFirstNodeInGroup("player") as Player;
        PlayerInventory = player.FindChild("Inventory") as Inventory;
        PlayerInventory.ResourceCountChanged += OnPlayerInventoryResourceCountChanged;
    }

    public void OnPlayerInventoryResourceCountChanged(ResourceItem type, int newCount)
    {
        ResourceItemDisplay currentDisplay = null;
        foreach(var display in ResourceItemDisplays)
        {
            if(display.ResourceType == type)
            {
                currentDisplay = display;
                currentDisplay.UpdateCount(newCount);
                break;
            }
        }

        if(currentDisplay == null)
        {
            var newDisplay = ItemDisplayTemplate.Instantiate() as ResourceItemDisplay;
            Grid.AddChild(newDisplay);
            newDisplay.ResourceType = type;
            newDisplay.UpdateCount(newCount);
            ResourceItemDisplays.Add(newDisplay);
        }
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
	}
}
