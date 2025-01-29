using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "MapModeSO", menuName = "SOFolder/MapModeSO")]

public class MapModeSO : ScriptableObject
{
    [Header("Map info")]
    [SerializeField] private int gameMode;
    [SerializeField] private string id;
    [Tooltip(
        "0 - mainTag\n" +
        "1 - mainland\n" +
        "2 - country\n" +
        "3 - region\n" +
        "4 - year\n" +
        "5 - level\n" +
        "6 - gamemode\n" +
        "7 - modeType\n" +
        "8 - name")]
    [SerializeField] private string[] tags = new string[9];
    [SerializeField] private string modeName;

    [SerializeField] private float percentFault;
    [SerializeField] public int hightScore;
    [SerializeField] public int attempts;


    [Header("Map building")]
    [SerializeField] private Sprite basicMap;
    [SerializeField] private Sprite externalBorder;
    [SerializeField] private Sprite internalBorder;
    [SerializeField] private Sprite waters;

    [SerializeField] private int numOfObjects;
    [SerializeField] private int numOfAnswers;

    [SerializeField] private Sprite[] regionsSprites;
    [SerializeField] private Color[] regionsSpritesColors;
    [SerializeField] private string[] objectsTrueAnswer;
    [SerializeField] private string[] answerTitles;
    [SerializeField] private Sprite[] answerIcons;
    [SerializeField] private Color[] answerColors;
    [SerializeField] private Vector2[] onMapPointsXY;
    [SerializeField] private Sprite[] onMapPointsSprites;

    public int Gamemode => gameMode;
    public string Id => id;
    public string[] Tags => tags;
    public string ModeName => modeName;

    public float PercentFault => percentFault;

    public Sprite BasicMap => basicMap;
    public Sprite ExternalBorder => externalBorder;
    public Sprite InternalBorder => internalBorder;
    public Sprite Waters => waters;

    public int NumOfObjects=> numOfObjects;
    public int NumOfAnswers => numOfAnswers;

    public Sprite[] RegionsSprites => regionsSprites;
    public Color[] RegionsSpritesColors => regionsSpritesColors;
    public string[] ObjectsTrueAnswer => objectsTrueAnswer;
    public string[] AnswerTitles => answerTitles;
    public Sprite[] AnswerIcons => answerIcons;
    public Color[] AnswerColors => answerColors;
    public Vector2[] OnMapPointsXY => onMapPointsXY;
    public Sprite[] OnMapPointsSprites => onMapPointsSprites;











}
