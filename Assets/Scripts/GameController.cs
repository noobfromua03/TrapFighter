using FVN.WindowSystem;
using System.Collections.Generic;
using UnityEngine;
using static FVN.WindowSystem.IntWindow;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    [SerializeField] private CharacterController character;
    [SerializeField] private Stage[] stages;
    [SerializeField] private GameObject rooms;
    [SerializeField] private FinalQuest finalQuest;

    private int stage = -1;

    private List<Note> readNotes = new List<Note>();
    private List<Note> allNotes = new List<Note>();

    private GameObject currentPlayGround;
    private GameObject currentDecorations;
    private LevelController currentController;

    [System.Serializable]
    private class Stage
    {
        public SkeletonType skeletonType;
        public LevelController controller1;
        public GameObject playGround1;
        public GameObject decorations1;
        public LevelController controller2;
        public GameObject playGround2;
        public GameObject decorations2;
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        allNotes = new List<Note>(NotesConfig.Instance.notes);
        SetupNextStage();
    }


    public void SetupNextStage()
    {
        if (stage >= 0)
        {
            Destroy(currentPlayGround);
            Destroy(currentDecorations);
            Destroy(currentController.gameObject);
        }

        stage++;

        if(stage >= stages.Length)
        {
            character.transform.position = Vector3.zero;
            finalQuest.gameObject.SetActive(true);
            finalQuest.Initialize(readNotes);
            return;
        }

        var stageData = stages[stage];

        rooms.SetActive(true);
        character.transform.position = Vector3.zero;
        character.CanMove = false;
        character.ResetHP();

        Windows.IntWindow("Вибери нову кінцівку: ", GetConfig(stageData.skeletonType)).OnCompleted += (result) =>
        {
            character.CanMove = true;
            var res = result.obj as CardResult;
            character.AddSkeleton(res.data, res.type);
        };
    }

    public void AddNote(Note note)
    {
        if (readNotes.Contains(note))
            return;

        readNotes.Add(note);
    }

    public void SetupCurrentLevel(bool first)
    {
        character.transform.position = Vector3.zero;
        rooms.SetActive(false);

        if (first)
        {
            currentPlayGround = Instantiate(stages[stage].playGround1);
            currentDecorations = Instantiate(stages[stage].decorations1);
            currentController = Instantiate(stages[stage].controller1);
        }
        else
        {
            currentPlayGround = Instantiate(stages[stage].playGround2);
            currentDecorations = Instantiate(stages[stage].decorations2);
            currentController = Instantiate(stages[stage].controller2);
        }
        currentController.Initialize(allNotes);
        currentController.OnFinish = SetupNextStage;
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
