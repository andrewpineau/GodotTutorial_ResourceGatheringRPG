using Godot;
using System;

[GlobalClass]
public partial class Item : Resource
{
    [Export]
    public Texture2D Texture { get; set; }
    [Export]
    public string DisplayName { get; set; }
}
