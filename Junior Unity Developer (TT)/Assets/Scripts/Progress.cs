using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Progress : MonoBehaviour
{
    [SerializeField] private Text _text1, _text2;
    [SerializeField] public static int win = -1, lose;
    public TextAsset JSONtext;
    public PlayerScore playerScore = new PlayerScore();
    // Start is called before the first frame update
    void Start()
    {
        playerScore = JsonUtility.FromJson<PlayerScore>(JSONtext.text);

        if (Progress.win == -1)
        {
            win = playerScore.Win;
            lose = playerScore.Lose;


        }

    }

    // Update is called once per frame
    void Update()
    {
        _text1.text = "Win: " + Progress.win;
        _text2.text = "Lose: " + Progress.lose;
    }

}

public class PlayerScore
{
    public int Lose;
    public int Win;
}
