using UnityEngine;
using UnityEngine.UI;


public class Region : MonoBehaviour
{
    public event System.Action<Region> onObjectClick;
    private Region _mo;
    [SerializeField] public SpriteClicker markable;
    [SerializeField] public Image image;
    [SerializeField] public string currentAnswer;
    [SerializeField] public string trueAnswer;

    private void OnEnable()
    {
        _mo = this;
    }
    void Start()
    {
        markable.onClick += onSpriteClick;
    }

    void Update()
    {
        
    }
    private void onSpriteClick(SpriteRenderer sprite)
    {
        image.color = SGameInfo.selectedAnswerColor;
        currentAnswer = SGameInfo.selectedAnswerID;
        onObjectClick?.Invoke(_mo);
    }
    public void ResetToDefault()
    {
        image.color = SGameInfo.selectedAnswerColor;
        currentAnswer = SGameInfo.selectedAnswerID;
    }
}
