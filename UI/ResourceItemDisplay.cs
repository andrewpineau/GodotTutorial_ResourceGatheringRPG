using Godot;
using System;

public partial class ResourceItemDisplay : HBoxContainer
{
    private ResourceItem _resourceType;
    public ResourceItem ResourceType 
    { 
        get { return _resourceType; }
        set { 
            _resourceType = value;
            TextureRect.Texture = _resourceType.Texture;
        }
    }
    public TextureRect TextureRect { get; set; }
    public Label Label { get; set; }

    public void UpdateCount(int count)
    {
        Label.Text = count.ToString();
    }
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
        TextureRect = GetNode<TextureRect>("TextureRect");
        Label = GetNode<Label>("Label");
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
