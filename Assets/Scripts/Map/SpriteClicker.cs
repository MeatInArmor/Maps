using System.Collections;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


public class SpriteClicker : MonoBehaviour
{
    [SerializeField] private Image image;

    public event System.Action<SpriteRenderer> onClick;
    private void OnEnable()
    {
    }
    private void OnMouseDown()
    {
        image.color = new Color(Random.value, Random.value, Random.value);
        onClick?.Invoke(GetComponent<SpriteRenderer>());
    }
   
}
