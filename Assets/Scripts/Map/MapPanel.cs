using System.Collections.Generic;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;



public class MapPanel : MonoBehaviour
{
    [SerializeField] private Collider2D collider_;
     
    [SerializeField] public Region regionPrefab;
    [SerializeField] public MarkAnswerPoint answerPointPrefab;
    [SerializeField] public PlayerPoint playerPointPrefab;


    [SerializeField] public Image basicMap;
    [SerializeField] public Image internalBorder;
    [SerializeField] public Image waters;
    [SerializeField] public Image externalBorder;

    [SerializeField] public List<Region> regions;
    [SerializeField] public List<PlayerPoint> pPoints;
    [SerializeField] public List<MarkAnswerPoint> aPoints;

    [SerializeField] public GameObject mapRegionsStore;
    [SerializeField] public GameObject mapPointsStore;


    [SerializeField] public Sprite drawableElement;

    [SerializeField] private InputActionAsset _inputActionAsset;
    private InputActionMap playerMap;
    private InputAction clickAction;

    private void Awake()
    {
        playerMap = _inputActionAsset.FindActionMap("Player");
        clickAction = playerMap.FindAction("Click");
    }

    private void OnEnable()
    {
        playerMap.Enable();
        clickAction.performed += CreateOrDeletePoint;
    }
    private void OnDisable()
    {
        playerMap.Disable();
        clickAction.performed -= CreateOrDeletePoint;
    }
    private void CreateOrDeletePoint(InputAction.CallbackContext context)
    {
        if (CurrentGameInfoST.currentGamemode.Gamemode == 1)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (CurrentGameInfoST.selectedAnswerID != "")
            {
                if (collider_.OverlapPoint(mousePosition)) // Проверяем внутри ли коллайдера
                {

                    PlayerPoint newPoint = Instantiate(playerPointPrefab, mousePosition, Quaternion.identity, mapPointsStore.transform);
                    newPoint.transform.localPosition = new Vector3(newPoint.transform.localPosition.x, newPoint.transform.localPosition.y, 0f);
                    WaitForCreate();
                    newPoint.image.sprite = CurrentGameInfoST.selectedAnswerSprite;
                    newPoint.currentAnswer = CurrentGameInfoST.selectedAnswerID;
                    pPoints.Add(newPoint);
                }
            }
            else
            {
                float radius = 20f;
                PlayerPoint deletePoint = Instantiate(playerPointPrefab, mousePosition, Quaternion.identity, mapPointsStore.transform);
                deletePoint.transform.localPosition = new Vector3(deletePoint.transform.localPosition.x, deletePoint.transform.localPosition.y, 0f);

                for (int i = 0; i < pPoints.Count;i++)
                {
                    PlayerPoint checkPoint = pPoints[i];
                    float distance = Vector2.Distance(deletePoint.transform.localPosition, checkPoint.transform.localPosition);
                    if(distance < radius)
                    {
                        pPoints.RemoveAt(i);
                        Destroy(checkPoint.gameObject);

                    }
                }
                Destroy(deletePoint.gameObject);
            }
        }
    }
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
        Region region = Instantiate(regionPrefab, mapRegionsStore.transform);
        StartCoroutine(WaitForCreate());
        region.image.sprite = sprite;
        region.markable.GetComponent<SpriteRenderer>().sprite = sprite;
        region.markable.AddComponent<PolygonCollider2D>();
        region.trueAnswer = trueAnswer;
        region.onObjectClick += SelectObject;
        regions.Add(region);
    }
    public void CreateAnswerPoint(Vector2 position, string trueAnswer, Sprite icon)
    {
        MarkAnswerPoint point = Instantiate(answerPointPrefab, mapPointsStore.transform);
        point.transform.localPosition = position;
        WaitForCreate();
        point.icon.sprite = icon;   
        point.trueAnswer = trueAnswer;
        aPoints.Add(point);
        //point.gameObject.SetActive(false);
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
        if (CurrentGameInfoST.currentGamemode.Gamemode == 0)
            foreach (Region region in regions)
            {
                region.ResetToDefault();
            }
        if (CurrentGameInfoST.currentGamemode.Gamemode == 1)
        {
            for (int i = 0; i < pPoints.Count; i++)
            {
                var thisPoint = pPoints[i];
                pPoints.RemoveAt(i);
                Destroy(thisPoint.gameObject);
            }
        }
    

    }
    public float ResultCollecting()
    {
        
        float goodAnswers = 0;
        float score = 0;
        if (CurrentGameInfoST.currentGamemode.Gamemode == 0)
        {
            for (int i = 0; i < regions.Count; i++)
            {
                if (regions[i].currentAnswer == regions[i].trueAnswer)
                    goodAnswers++;
            }
            score = goodAnswers / regions.Count;
            Debug.Log($"{score} {goodAnswers} {regions.Count}");
            return score;
        }
        if (CurrentGameInfoST.currentGamemode.Gamemode == 1)
        {

            foreach(var aPoint in aPoints)
            {
                aPoint.gameObject.SetActive(true);
                foreach(var pPoint in pPoints)
                {
                    float distance = Vector2.Distance(aPoint.transform.localPosition, pPoint.transform.localPosition);
                    Debug.Log($"dist {distance} ans {aPoint.trueAnswer == pPoint.currentAnswer} uncheck {!pPoint.checked_}");
                    if (distance <= CurrentGameInfoST.currentGamemode.PercentFault && aPoint.trueAnswer == pPoint.currentAnswer && !pPoint.checked_)
                    {
                        pPoint.checked_ = true;
                        pPoint.border.SetActive(true);  
                        goodAnswers++;
                        break;
                    }
                }
            }
            int unsigned_pPonts = 0;
            foreach (var pPoint in pPoints)
                if(!pPoint.checked_)
                    unsigned_pPonts++;
            float step = 1f / aPoints.Count;
            score = step * goodAnswers - (unsigned_pPonts * step / 2);
            if (score <= 0f)
                score = 0f;
            Debug.Log($"{score} {goodAnswers} {unsigned_pPonts} {step}");
            return score;
        }
        return 0;
    }
    IEnumerator WaitForCreate()
    {
        yield return null;
        yield break;
    }
}
