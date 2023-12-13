using Godot;
using System;

public partial class ItemButton : Button
{
	private Item _item;
    [Export]
    public Item Item { 
		get { return _item; } 
		set { 
			_item = value;
			Icon = _item.Texture;
		} 
	}

    public HandEquip HandEquip { get; set; }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
		
    }

	public void OnButtonPressed()
	{
		if(Item is EquippableItem)
		{
			if(HandEquip != null)
			{
				HandEquip.EquippedItem = Item as EquippableItem;
			}
		}
	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
