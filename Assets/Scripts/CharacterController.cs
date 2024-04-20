using FVN.WindowSystem;
using System.Collections.Generic;
using UnityEngine;
using static FVN.WindowSystem.IntWindow;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private PlayerMovement movement;

    public Transform rightArm;
    public Transform leftArm;
    public Transform rightLeg;
    public Transform leftLeg;
    public Transform head;

    private float defaultHP = 100;
    private float defaultSpeed = 10;
    private float hp = 100;

    private Dictionary<SkeletonType, SkeletonData> skeletons = new Dictionary<SkeletonType, SkeletonData>();

    public bool CanMove { set => movement.CanMove = value; }

    public void ResetHP()
    {
        hp = defaultHP;
        foreach(var skeleton in skeletons)
            hp *= skeleton.Value.healthMultiplier;
    }

    public void AddSkeleton(SkeletonData data, SkeletonType type)
    {
        var container = GetTransformSkeleton(type);
        var go = Instantiate(data.obj, container);

        if(go.TryGetComponent(out SkeletonWeapon weapon))
            weapon.Initialize(data);

        skeletons.Add(type, data);

        var speed = defaultSpeed;
        foreach (var skeleton in skeletons)
            speed *= skeleton.Value.speedMultiplier;

        movement.ChangeSpeed(speed);
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

    public void TakeDamage(float damage)
    {
        Debug.Log("Take damage");
        hp -= damage;
        if(hp <= 0)
        {
            Debug.Log("Game Over");
        }
    }    
}
