using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   

using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private MapModeSO[] allMapModes;
    [SerializeField] private MenuTagsPanel tagsPanel;
    [SerializeField] private Text gamemodeName;

    [SerializeField] private MenuGamemodePanel GamemodesPanel;
    [SerializeField] private CommonGameInfoSO gameInfo;
    [SerializeField] private List<string> allTagsList;
    [SerializeField] private List<string> unusedTagsList;



    private void OnEnable()
    {
        GamemodesPanel.onGamemodeSelect += SetGamemodeNameText;
        GamemodesPanel.CreateGamemodesList(allMapModes);
    }

    private void SetGamemodeNameText(string name_)
    {
        gamemodeName.text = name_;
    }
    public void LoadGameScene()
    {
        SceneManager.LoadScene(1);
    }
}
