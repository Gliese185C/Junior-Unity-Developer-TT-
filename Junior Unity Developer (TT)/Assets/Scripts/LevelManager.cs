using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{

    public int bots;
    public float delayTime = 3f;
    public string winUI;
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        if (bots == 0)
        {
            StartCoroutine(DelayCoroutine());
        }
    }

    IEnumerator DelayCoroutine()
    {

        yield return new WaitForSeconds(delayTime);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        WinUI();
    }

    public void WinUI()
    {
        Progress.win += 1;
        SaveData();
        SceneManager.LoadScene(winUI);
    }

    public void SaveData()
    {
        PlayerScore data = new PlayerScore();
        data.Win = Progress.win;
        data.Lose = Progress.lose;

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(Application.dataPath + "/Score.json", json);
    }
}
