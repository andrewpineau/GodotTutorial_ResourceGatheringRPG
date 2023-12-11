using Godot;
using System;

[GlobalClass]
public partial class EquippableItem : Resource
{
    [Export]
    public Texture2D Texture { get; set; }
    [Export]
    public string DisplayName { get; set; }
}
