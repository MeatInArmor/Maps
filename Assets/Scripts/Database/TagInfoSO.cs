using UnityEngine;

[CreateAssetMenu(fileName = "TagInfoSO", menuName = "SOFolder/TagInfoSO")]

public class TagInfoSO : ScriptableObject
{
    [SerializeField] private string tagType;
    [SerializeField] private string tagName;
    [SerializeField] private string tagValueName;
    [SerializeField] private TagInfoSO[] childTags;

    public string TagType => tagType;
    public string TagName => tagName;
    public string TagValueName => tagValueName;
    public TagInfoSO[] ChildTags => childTags;

}
