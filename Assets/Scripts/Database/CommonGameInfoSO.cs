using UnityEngine;

[CreateAssetMenu(fileName = "CommonGameInfoSO", menuName = "SOFolder/CommonGameInfoSO")]

public class CommonGameInfoSO : ScriptableObject
{
    [SerializeField] private MapModeSO[] allMaps;
    [SerializeField] private string[] allTagTypes;
    [SerializeField] private TagInfoSO[] allTags;
    [SerializeField] private string[] tagsName;

}
