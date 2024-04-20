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
    public string description;
    public float speedMultiplier;
    public float damageMultiplier;
    public float healthMultiplier;
    public float attackSpeedMultiplier;
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