using Godot;
using System;

[GlobalClass]
public partial class HarvestingTool : EquippableItem
{
    [Export]
    public int MinDamage { get; set; } = 1;
    [Export]
    public int MaxDamage { get; set; } = 1;
    public void Harvest(ResourceNode resourceNode)
    {

    }
}
