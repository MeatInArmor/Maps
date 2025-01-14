using System.Collections.Generic;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class MapPanel : MonoBehaviour
{
    [SerializeField] public Region regionPrefab;
    [SerializeField] public Region pointPrefab;

    [SerializeField] public Image basicMap;
    [SerializeField] public Image internalBorder;
    [SerializeField] public Image waters;
    [SerializeField] public Image externalBorder;

    [SerializeField] public List<Region> regions;
    [SerializeField] public GameObject mapObjectsStore;
    [SerializeField] public Sprite drawableElement;

    public void SetBasicMap(Sprite basic, Sprite ex_, Sprite in_, Sprite water)
    {
        if (basic != null)
            basicMap.sprite = basic;
        if (ex_ != null)
            externalBorder.sprite = ex_;
        if (in_ != null)
            internalBorder.sprite = in_;
        if (water != null)
            waters.sprite = water;
    

    }

    public void CreateRegion(Sprite sprite, string trueAnswer)
    {
        Region region = Instantiate(regionPrefab, mapObjectsStore.transform);
        StartCoroutine(WaitForCreate());
        region.image.sprite = sprite;
        region.markable.GetComponent<SpriteRenderer>().sprite = sprite;
        region.markable.AddComponent<PolygonCollider2D>();
        region.trueAnswer = trueAnswer;
        region.onObjectClick += SelectObject;
        regions.Add(region);
    }
    public void CreatePoint()
    {

    }
    public void AddTextable()
    {

    }
    public void SelectObject(Region region) 
    {

    }
    public void ResetSekected()
    {
        foreach(Region region in regions)
        {
            region.ResetToDefault();
        }
    }
    public float ResultCollecting()
    {
        
        float goodAnswers = 0;
        for(int i = 0; i < regions.Count; i++)
        {
            if (regions[i].currentAnswer == regions[i].trueAnswer)
                goodAnswers++;
        }
        float score = goodAnswers / regions.Count;
        Debug.Log($"{score} {goodAnswers} {regions.Count}");
        return score;
    }
    IEnumerator WaitForCreate()
    {
        yield return null;
        yield break;
    }
}
