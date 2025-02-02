using UnityEngine;
using UnityEngine.UI;

public class Region : MonoBehaviour
{
    public event System.Action<Region> onObjectClick;
    private Region reg;
    [SerializeField] public SpriteClicker markable;
    [SerializeField] public Image image;
    [SerializeField] public string currentAnswer;
    [SerializeField] public string trueAnswer;

    private void OnEnable()
    {
        reg = this;
        markable.onClick += onSpriteClick;
    }
 
    private void onSpriteClick(SpriteRenderer sprite)
    {
        image.color = CurrentGameInfoST.selectedAnswerColor;
        currentAnswer = CurrentGameInfoST.selectedAnswerID;
        onObjectClick?.Invoke(reg);
    }
    public void ResetToDefault()
    {
        image.color = CurrentGameInfoST.selectedAnswerColor;
        currentAnswer = CurrentGameInfoST.selectedAnswerID;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<CheckPoint>(out var cp))
        {
            onSpriteClick(markable.GetComponent<SpriteRenderer>());
        }
        Destroy(other.gameObject);
    }
}
