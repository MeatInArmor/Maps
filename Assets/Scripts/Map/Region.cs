using UnityEngine;
using UnityEngine.UI;


public class Region : MonoBehaviour
{
    public event System.Action<Region> onObjectClick;
    [SerializeField] public SpriteClicker markable;
    [SerializeField] public Image image;
    [SerializeField] public string currentAnswer;
    [SerializeField] public string trueAnswer;

    private void OnEnable()
    {
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
        image.color = CurrentGameInfoST.selectedAnswerColor;
        currentAnswer = CurrentGameInfoST.selectedAnswerID;
        onObjectClick?.Invoke(this);
    }
    public void ResetToDefault()
    {
        image.color = CurrentGameInfoST.selectedAnswerColor;
        currentAnswer = CurrentGameInfoST.selectedAnswerID;
    }
}
