using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "MapStructureSO", menuName = "SOFolder/MapStructureSO")]

public class MapStructure : ScriptableObject
{
    [Header("Map info")]
    [SerializeField] private int gameMode;
    [SerializeField] private string id;
    [Tooltip(
        "0 - name\n" +
        "1 - country\n" +
        "2 - region\n" +
        "3 - year")]
    [SerializeField] private string[] tags;
    [SerializeField] private float percentFault;
    [SerializeField] public int hightScore;

    [Header("Map building")]
    [SerializeField] private Sprite basicMap;
    [SerializeField] private Sprite externalBorder;
    [SerializeField] private Sprite internalBorder;
    [SerializeField] private Sprite waters;

    [SerializeField] private int numOfObjects;
    [SerializeField] private int numOfAnswers;

    [SerializeField] private Sprite[] regionsSprites;
    [SerializeField] private Color[] regionsSpritesColors;
    [SerializeField] private string[] regionsTrueAnswer;
    [SerializeField] private string[] answerTitles;
    [SerializeField] private Sprite[] answerIcons;
    [SerializeField] private Color[] answerColors;
    [SerializeField] private Vector2[] onMapPointsXY;
    [SerializeField] private Sprite[] onMapPointsSprites;

    public int Gamemode => gameMode;
    public string Id => id;
    public string[] Tags => tags;
    public float PercentFault => percentFault;

    public Sprite BasicMap => basicMap;
    public Sprite ExternalBorder => externalBorder;
    public Sprite InternalBorder => internalBorder;
    public Sprite Waters => waters;

    public int NumOfObjects=> numOfObjects;
    public int NumOfAnswers => numOfAnswers;

    public Sprite[] RegionsSprites => regionsSprites;
    public Color[] RegionsSpritesColors => regionsSpritesColors;
    public string[] RegionsTrueAnswer => regionsTrueAnswer;
    public string[] AnswerTitles => answerTitles;
    public Sprite[] AnswerIcons => answerIcons;
    public Color[] AnswerColors => answerColors;
    public Vector2[] OnMapPointsXY => onMapPointsXY;
    public Sprite[] OnMapPointsSprites => onMapPointsSprites;











}
