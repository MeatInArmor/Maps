using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class MenuTagsPanel : MonoBehaviour
{
    public event System.Action<List<string>> onTagsChange;

    [SerializeField] private MenuTagObject startTag;
    [SerializeField] private MenuTagObject tagPrefab;
    [SerializeField] private NewTagButton newTagButton;
    [SerializeField] private List<MenuTagObject> currentTagsList;
    [SerializeField] private List<string> tagsTypes;


    private void OnEnable()
    {
        //MenuTagObject tagObject = Instantiate(tagPrefab, transform);
        //StartCoroutine(WaitForCreate());
        //currentTagsList.Insert(0, tagObject);
        //newTagButton.GetComponent<RectTransform>().SetAsLastSibling();
        //onTagsChange?.Invoke(tagsTypes);

    }

    IEnumerator WaitForCreate()
    {
        yield return null;
        yield break;
    }
}
