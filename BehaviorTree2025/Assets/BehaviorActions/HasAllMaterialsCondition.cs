using System;
using Unity.Behavior;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "HasAllMaterials", story: "Has all materials", category: "Conditions", id: "45cb682f50cb7383b81822afb3f0d007")]
public partial class HasAllMaterialsCondition : Condition
{

    public override bool IsTrue()
    {
        return CraftingBenchStatus.HasAllMaterials();
    }
}
