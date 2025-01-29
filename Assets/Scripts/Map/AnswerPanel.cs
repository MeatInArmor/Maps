using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerPanel : MonoBehaviour
{
    [SerializeField] public AnswerVariant answerPrefab;

    [SerializeField] public List<AnswerVariant> answers;
    [SerializeField] public AnswerVariant answerClear;
    private void OnEnable()
    {
        answers.Add(answerClear);
        
    }
    private void Start()
    {
        if (CurrentGameInfoST.currentGamemode.Gamemode == 0)
        {
            answerClear.iconVariant.SetActive(false);
        }
        else
        {
            answerClear.colorVariant.SetActive(false);
        }
        answerClear.onAnswerVariantClick += AnswerClicked;
    }
    public void CreateAnswerVariant(Sprite sprite, Color color, string text, int id)
    {
        AnswerVariant answer = Instantiate(answerPrefab, transform);
        StartCoroutine(WaitForCreate());
        answerClear.transform.SetAsLastSibling();
        answer.iconPicture.sprite = sprite;
        answer.colorPicture.color = color;
        answer.answerDescription.text = text;
        if (CurrentGameInfoST.currentGamemode.Gamemode == 0)
        {
            answer.iconVariant.SetActive(false);
        }
        else
        {
            answer.colorVariant.SetActive(false);
        }
        answer.answerID = id.ToString();
        answer.onAnswerVariantClick += AnswerClicked;
        answers.Insert(id, answer);

    }

    public void AnswerClicked()
    {
        foreach(AnswerVariant answer in answers)
        {
            if(CurrentGameInfoST.selectedAnswerID != answer.answerID)
            {
                answer.DeselectAnswerVariant();
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
