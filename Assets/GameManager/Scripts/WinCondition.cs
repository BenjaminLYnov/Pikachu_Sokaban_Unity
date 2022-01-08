using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public BallAbove[] cases;
    public GameObject pikachu;
    public GameObject win;
    public GameObject back;

    // Update is called once per frame
    void Update()
    {
        if (CheckActivationCase())
        {
            pikachu.GetComponent<Move>().enabled = false;
            win.SetActive(true);
            back.SetActive(false);
        }
    }

    private bool CheckActivationCase()
    {
        foreach (BallAbove item in cases)
            if (!item.activated)
                return false;

        return true;
    }
}
