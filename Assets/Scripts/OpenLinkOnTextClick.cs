using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OpenLinkOnTextClick : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private string linkUrl = "https://www.example.com";

    public void OnPointerClick(PointerEventData eventData)
    {
        Application.OpenURL(linkUrl);
    }
}

