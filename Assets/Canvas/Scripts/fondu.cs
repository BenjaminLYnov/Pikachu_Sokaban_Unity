using UnityEngine;
using UnityEngine.UI;

public class fondu : MonoBehaviour
{
    float transparence = 0;


    private void Start()
    {
    }

    void Update()
    {
        GetComponent<Image>().color = new Color(1, 1, 1, transparence);
        if (transparence <= 1) transparence += 0.01f;
    }

}
