using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerPanel : MonoBehaviour
{
    [SerializeField] public AnswerVariant answerPrefab;

    [SerializeField] public List<AnswerVariant> answers;
    [SerializeField] public AnswerVariant answerClear;
    private void Start()
    {
        answerClear.onAnswerVariantClick += AnswerClicked;
    }
    public void CreateAnswerVariant(Sprite sprite, Color color, string text, int id)
    {
        AnswerVariant answer = Instantiate(answerPrefab, transform);
        StartCoroutine(WaitForCreate());
        answerClear.transform.SetAsLastSibling();
        if (sprite != null)
            answer.answerPicture.sprite = sprite;
        else
            answer.answerPicture.color = color;
        answer.answerDescription.text = text;
        answer.answerID = id.ToString();
        answer.onAnswerVariantClick += AnswerClicked;
        answers.Insert(id, answer);

    }

    public void AnswerClicked()
    {
        foreach(AnswerVariant answer in answers)
        {
            if(SGameInfo.selectedAnswerID != answer.answerID)
            {
                answer.resetColor();
            }
        }
    }
    public void ClearAnswer()
    {
        answerClear.onClick();
    }
    IEnumerator WaitForCreate()
    {
        yield return null;
        yield break;

    }
}
