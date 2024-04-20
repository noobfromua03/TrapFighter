using FVN.WindowSystem;
using System.Collections.Generic;
using UnityEngine;
using static FVN.WindowSystem.IntWindow;

public class CharacterController : MonoBehaviour
{
    public Transform rightArm;
    public Transform leftArm;
    public Transform rightLeg;
    public Transform leftLeg;
    public Transform head;

    private void Awake()
    {
        List<ISkeletonConfig> configs = new()
        {
            HeadConfig.Instance,
            RightArmConfig.Instance,
            LeftArmConfig.Instance,
            RightLegConfig.Instance,
            LeftLegConfig.Instance
        };

        foreach (var config in configs)
            ChangeSkeleton(config.Skeletons[1], config.Type);
    }

    public void ChangeSkeleton(SkeletonData data, SkeletonType type)
    {
        var container = GetTransformSkeleton(type);
        var go = Instantiate(data.obj, container);
        go.transform.localPosition = data.pos;
        go.transform.localRotation = Quaternion.Euler(data.rot);
    }

    public Transform GetTransformSkeleton(SkeletonType type) =>
         type switch
         {
             SkeletonType.Head => head,
             SkeletonType.RightArm => rightArm,
             SkeletonType.LeftArm => leftArm,
             SkeletonType.RightLeg => rightLeg,
             SkeletonType.LeftLeg => leftLeg,
             _ => throw new System.NotImplementedException()
         };

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Windows.IntWindow("title", HeadConfig.Instance).OnCompleted += (result) =>
            {
                var res = result.obj as CardResult;
                ChangeSkeleton(res.data, res.type);
            };
        }
    }
}
