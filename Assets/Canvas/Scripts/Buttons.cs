using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections;

public class Buttons : MonoBehaviour
{
    public BackupState backupState;
    public GameObject pikachu;

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Back()
    {
        if (backupState.BallsName.Count > 0)
        {
            pikachu.transform.position = new Vector3(backupState.pikachuPosition[backupState.pikachuPosition.Count - 1].x, pikachu.transform.position.y, backupState.pikachuPosition[backupState.pikachuPosition.Count - 1].y);
            pikachu.transform.eulerAngles = new Vector3(0, backupState.pikachuPosition[backupState.pikachuPosition.Count - 1].z, 0);
            pikachu.transform.Translate(Vector3.back * 0.3f);

            GameObject.Find(backupState.BallsName[backupState.BallsName.Count - 1]).transform.position = backupState.BallsPosition[backupState.BallsPosition.Count - 1];

            backupState.BallsName.RemoveAt(backupState.BallsName.Count - 1);
            backupState.BallsPosition.RemoveAt(backupState.BallsPosition.Count - 1);
            backupState.pikachuPosition.RemoveAt(backupState.pikachuPosition.Count - 1);
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}

