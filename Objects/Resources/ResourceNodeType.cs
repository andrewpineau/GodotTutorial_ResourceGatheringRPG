using Godot;
using System;

[GlobalClass]
public partial class ResourceNodeType : Resource
{
    [Export]
    public string DisplayName { get; set; }
}
