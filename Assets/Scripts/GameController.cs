using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public event System.Action<int> onObjectClick;
    //public event System.Action<int> onObjectClick;

    [SerializeField] public MapStructure mode;

    [SerializeField] public AnswerPanel answerPanel;
    [SerializeField] public MapPanel mapPanel;

    [SerializeField] public Text modeName;
    [SerializeField] public Text recordText;
    [SerializeField] public Text wonText;




    private void OnEnable()
    {
        SGameInfo.selectedAnswerID = "";
        SGameInfo.selectedAnswerColor = Color.white;

        mapPanel.SetBasicMap(mode.BasicMap, mode.ExternalBorder, mode.InternalBorder, mode.Waters);
        if (mode.Gamemode == 0)
        {
            for (int i = 0; i < mode.RegionsSprites.Length; i++)
            {
                mapPanel.CreateRegion(mode.RegionsSprites[i], mode.RegionsTrueAnswer[i]);
            }
            for (int j = 0; j < mode.AnswerColors.Length; j++)
            {
                answerPanel.CreateAnswerVariant(null, mode.AnswerColors[j], mode.AnswerTitles[j], j);

            }
        }
    }
    void Start()
    {
        recordText.text += $"{mode.hightScore}%";
    }

    void Update()
    {
        
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
        SceneManager.LoadScene(0);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
