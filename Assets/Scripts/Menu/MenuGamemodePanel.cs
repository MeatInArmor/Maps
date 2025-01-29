using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuGamemodePanel : MonoBehaviour
{
    public event System.Action<string> onGamemodeSelect;

    [SerializeField] public GameObject content;
    [SerializeField] public MenuGamemodeVariant gm_variantPrefab;

    [SerializeField] public List<MenuGamemodeVariant> variants;

    public void CreateGamemodesList(MapModeSO[] mapModes)
    {
        for (int i = 0; i < mapModes.Length; i++)
        {
            MenuGamemodeVariant newVariant = Instantiate(gm_variantPrefab, content.transform);
            variants.Add(newVariant);
            newVariant.onClick += OnGameVariantSelect;
        }
        StartCoroutine(WaitForCreate());
        for (int i = 0; i < variants.Count;i++)
        {
            variants[i].SetGamemodeInfo(mapModes[i]);
        }
    }
    public void OnGameVariantSelect(MapModeSO gm)
    {
        onGamemodeSelect?.Invoke(gm.ModeName);
    }
    IEnumerator WaitForCreate()
    {
        yield return null;
        yield break;
    }
}
