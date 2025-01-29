using UnityEngine;
using UnityEngine.UI;


public class AnswerVariant : MonoBehaviour
{
    public event System.Action onAnswerVariantClick;

    [SerializeField] public GameObject colorVariant;
    [SerializeField] public GameObject iconVariant;

    [SerializeField] public Image colorPicture;
    [SerializeField] public Image iconPicture;

    [SerializeField] public Text answerDescription;
    [SerializeField] public string answerID;

    [SerializeField] public Image background;
    [SerializeField] public Color defaultColor;
    [SerializeField] public Color selectedColor;

    public void DeselectAnswerVariant()
    {
        background.color = defaultColor;

    }
    public void onClick()
    {
        background.color = selectedColor;
        CurrentGameInfoST.selectedAnswerID = answerID;
        CurrentGameInfoST.selectedAnswerColor = colorPicture.color;
        CurrentGameInfoST.selectedAnswerSprite = iconPicture.sprite;

        onAnswerVariantClick?.Invoke();
    }
}
