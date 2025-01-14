using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class AnswerVariant : MonoBehaviour
{
    public event System.Action onAnswerVariantClick;

    [SerializeField] public Image answerPicture;
    [SerializeField] public Text answerDescription;
    [SerializeField] public string answerID;

    [SerializeField] public Image thisImage;
    [SerializeField] public Color defaultColor;
    [SerializeField] public Color selectedColor;

    public void resetColor()
    {
        thisImage.color = defaultColor;
    }
    public void onClick()
    {
        thisImage.color = selectedColor;
        bool isSpriteUsed = true;
        if (answerPicture.sprite == null)
            isSpriteUsed = false;
        SGameInfo.selectedAnswerID = answerID;
        SGameInfo.selectedAnswerColor = answerPicture.color;

        onAnswerVariantClick?.Invoke();
    }
}
