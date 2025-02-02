using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameController : MonoBehaviour
{
    //public event System.Action<int> onObjectClick;

    [SerializeField] public MapModeSO mode;

    [SerializeField] public AnswerPanel answerPanel;
    [SerializeField] public MapPanel mapPanel;

    [SerializeField] public Text modeName;
    [SerializeField] public Text recordText;
    [SerializeField] public Text wonText;




   
    void Start()
    {
        recordText.text += $"{mode.hightScore}%";
        modeName.text = $"{mode.ModeName}"; 

    }
    private void OnEnable()
    {


        if (CurrentGameInfoST.currentGamemode != null)
            mode = CurrentGameInfoST.currentGamemode;
        else
            CurrentGameInfoST.currentGamemode = mode;

        CurrentGameInfoST.selectedAnswerID = "";
        CurrentGameInfoST.selectedAnswerColor = Color.white;


        mapPanel.SetBasicMap(mode.BasicMap, mode.ExternalBorder, mode.InternalBorder, mode.Waters);
        if (mode != null)
        {
            if (mode.Gamemode == 0)
            {
                for (int i = 0; i < mode.RegionsSprites.Length; i++)
                {
                    mapPanel.CreateRegion(mode.RegionsSprites[i], mode.ObjectsTrueAnswer[i]);
                    StartCoroutine(WaitForCreate());

                }
                for (int j = 0; j < mode.AnswerColors.Length; j++)
                {
                    answerPanel.CreateAnswerVariant(null, mode.AnswerColors[j], mode.AnswerTitles[j], j);

                }
            }
            if(mode.Gamemode == 1)
            {

                for (int i = 0;i < mode.OnMapPointsXY.Length;i++)
                    mapPanel.CreateAnswerPoint(mode.OnMapPointsXY[i], mode.ObjectsTrueAnswer[i], mode.OnMapPointsSprites[i]);
                for (int j = 0; j < mode.AnswerIcons.Length; j++)
                    answerPanel.CreateAnswerVariant(mode.AnswerIcons[j], Color.white, mode.AnswerTitles[j], j);

            }
        }
    }

    public void ResetSelected()
    {
        answerPanel.ClearAnswer();
        mapPanel.ResetSekected();
    }
    public void CheckResults()
    {
        int totalScore = (int)(Math.Round(mapPanel.ResultCollecting(), 2) * 100);
        wonText.gameObject.SetActive(true);
        wonText.text += $"{totalScore}%";
        if(mode.hightScore < totalScore)
        {
            mode.hightScore = totalScore;
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(1);
    }
    public void GoToMenuScene()
    {
        SceneManager.LoadScene(0);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    IEnumerator WaitForCreate()
    {
        yield return null;
        yield break;
    }
}
