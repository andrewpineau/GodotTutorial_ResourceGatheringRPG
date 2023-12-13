using Godot;
using System;
using System.Linq;

public partial class Hotbar : Control
{
    public Player Player { get; set; }
    public HandEquip HandEquip { get; set; }
    public GridContainer GridContainer { get; set; }
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
        GridContainer = GetNode<GridContainer>("GridContainer");
        Player = GetTree().GetFirstNodeInGroup("player") as Player;
        if(Player != null)
        {
            HandEquip = Player.FindChild("HandEquip") as HandEquip;
        }
        foreach(var child in GridContainer.GetChildren())
        {
            if(child is ItemButton)
            {
                (child as ItemButton).HandEquip = HandEquip;
            }
        }
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
