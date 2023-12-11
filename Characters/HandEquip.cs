using Godot;
using System;

public partial class HandEquip : Sprite2D
{
    public Area2D EquipHitbox { get; set; }
    private EquippableItem _equippedItem;
    [Export]
    public EquippableItem EquippedItem
    {
        get => _equippedItem;
        set
        {
            _equippedItem = value;
            this.Texture = _equippedItem.Texture;
        }
    }
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
        EquipHitbox = GetNode<Area2D>("Area2D");

    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
    public void OnArea2DBodyEntered(Node2D body)
    {
        if (EquippedItem.HasMethod("interact_with_body"))
        {

        }
    }
}
