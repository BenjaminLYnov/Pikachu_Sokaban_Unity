using UnityEngine;

public class RedimensionImage : MonoBehaviour
{
    private RectTransform rt;

    void Start()
    {
        rt = GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(Screen.width, Screen.height);
    }

    void Update()
    {
        rt.sizeDelta = new Vector2(Screen.width, Screen.height);
    }
}
