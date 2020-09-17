using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trashUIScript : MonoBehaviour
{
    public GameObject[] gos;
    private float barLength;
    private float initialTrash;

    private void Awake()
    {
        gos = GameObject.FindGameObjectsWithTag("Trash");
        initialTrash = gos.Length;
    }

    void Update()
    {
        
        gos = GameObject.FindGameObjectsWithTag("Trash") ;
        barLength = (initialTrash - gos.Length) * 52 / initialTrash;

        Set_Width(gameObject, barLength);
    }


    public static void Set_Width(Component component, float width)
    {
        if (component != null)
        {
            Set_Width(component.gameObject, width);
        }
    }
    public static void Set_Width(GameObject gameObject, float width)
    {
        if (gameObject != null)
        {
            var rectTransform = gameObject.GetComponent<RectTransform>();
            if (rectTransform != null)
            {
                rectTransform.sizeDelta = new Vector2(width, rectTransform.sizeDelta.y);
            }
        }
    }
}
