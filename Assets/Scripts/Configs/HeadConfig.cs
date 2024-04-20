using FVN.Configs;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonConfig<TConfig> : AbstractConfig<TConfig>, ISkeletonConfig where TConfig : AbstractConfig<TConfig>
{
    public List<SkeletonData> skeletons;
    public virtual SkeletonType type => SkeletonType.Head;

    public SkeletonType Type => type;

    public List<SkeletonData> Skeletons => skeletons;
}

[System.Serializable]
public class SkeletonData
{
    public GameObject obj;
    public Vector3 pos;
    public Vector3 rot;
    public string description;
}

public enum SkeletonType
{
    Head,
    RightArm,
    LeftArm,
    RightLeg,
    LeftLeg
}

public interface ISkeletonConfig
{
    public List<SkeletonData> Skeletons { get; }
    public SkeletonType Type { get; }
}

public class HeadConfig : SkeletonConfig<HeadConfig>
{

}

public class RightArmConfig : SkeletonConfig<RightArmConfig>
{
    public override SkeletonType type => SkeletonType.RightArm;
}

public class LeftArmConfig : SkeletonConfig<LeftArmConfig>
{
    public override SkeletonType type => SkeletonType.LeftArm;
}

public class RightLegConfig : SkeletonConfig<RightLegConfig>
{
    public override SkeletonType type => SkeletonType.RightLeg;
}

public class LeftLegConfig : SkeletonConfig<LeftLegConfig>
{
    public override SkeletonType type => SkeletonType.LeftLeg;
}
