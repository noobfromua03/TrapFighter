using FVN.WindowSystem;
using System.Collections.Generic;
using UnityEngine;
using static FVN.WindowSystem.IntWindow;

public class GameController : MonoBehaviour
{
    [SerializeField] private CharacterController character;
    [SerializeField] private Stage[] stages;

    private int stage = -1;

    private List<Note> notes = new List<Note>();

    [System.Serializable]
    private class Stage
    {
        public SkeletonType skeletonType;
    }

    private void Start()
    {
        SetupNextStage();
    }


    public void SetupNextStage()
    {
        stage++;

        var stageData = stages[stage];

        Windows.IntWindow("title", GetConfig(stageData.skeletonType)).OnCompleted += (result) =>
        {
            var res = result.obj as CardResult;
            character.AddSkeleton(res.data, res.type);
        };
    }

    public void AddNote(Note note)
    {
        if(notes.Contains(note))
            return;

        notes.Add(note);
    }

    private void SetupCurrentLevel()
    { 

    }

    private ISkeletonConfig GetConfig(SkeletonType type)
    {
        return type switch
        {
            SkeletonType.Head => HeadConfig.Instance,
            SkeletonType.RightArm => RightArmConfig.Instance,
            SkeletonType.LeftArm => LeftArmConfig.Instance,
            SkeletonType.RightLeg => RightLegConfig.Instance,
            SkeletonType.LeftLeg => LeftLegConfig.Instance,
            _ => null
        };
    }
}
