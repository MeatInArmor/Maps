using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MenuGamemodeVariant : MonoBehaviour
{
    public event System.Action<MapModeSO> onClick;

    [SerializeField] private MapModeSO gameMode;
    [SerializeField] private Image nameBack;
    [SerializeField] private Image resultBack;
    [SerializeField] private Text nameText;
    [SerializeField] private Text resultText;
    [SerializeField] private string noResultText;


    public void SetGamemodeInfo(MapModeSO mode)
    {
        gameMode = mode;

        nameText.text = gameMode.ModeName;
        if(gameMode.hightScore == 0)
        {
            resultText.text = noResultText;
        }
        else
            resultText.text = $"{gameMode.hightScore}%";
    }
    public void OnClick()
    {
        CurrentGameInfoST.currentGamemode = gameMode;
        onClick?.Invoke(gameMode);
    }
}
