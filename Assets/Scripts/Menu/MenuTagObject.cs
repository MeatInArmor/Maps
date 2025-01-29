using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class MenuTagObject : MonoBehaviour
{
    [SerializeField] private TagInfoSO tagData;
    [SerializeField] private string tagType;
    [SerializeField] private string tagName;
    [SerializeField] private string tagValueName;
    [SerializeField] private Text textField;



    public void SetData(TagInfoSO tagData)
    {
        tagType = tagData.TagType;
        tagName = tagData.TagName;
        tagValueName = tagData.TagValueName;
        textField.text = tagValueName;
    }
    public string GetTagType()
    {
        return tagType;
    }
    public string GetTagName()
    {
        return tagName;
    }
}
