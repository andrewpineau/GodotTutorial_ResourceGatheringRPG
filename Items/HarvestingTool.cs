using Godot;
using System;
using System.Linq;

[GlobalClass]
public partial class HarvestingTool : EquippableItem
{
    [Export]
    public int MinAmount { get; set; } = 1;
    [Export]
    public int MaxAmount { get; set; } = 1;
    [Export]
    public ResourceNodeType[] EffectedNodeTypes { get; set; }

    public void interact_with_body(Node2D body)
    {
        var resourceNode = body as ResourceNode;
        if (resourceNode != null)
        {
            var matchingResources = resourceNode.ResourceNodeTypes.Intersect(EffectedNodeTypes);
            if (matchingResources.Any())
            {
                GD.Print($"Interact with resource node {matchingResources.First().DisplayName} on {body.Name}");
                resourceNode.Harvest(GD.RandRange(MinAmount, MaxAmount));
            }
        }
    }
}
