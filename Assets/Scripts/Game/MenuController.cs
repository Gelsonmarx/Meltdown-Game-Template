using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI highestScore;
    void Start()
    {
        int high = PlayerPrefs.GetInt("HighestScore", 0);
        bool activeHigh = high >0;
        highestScore.gameObject.SetActive(activeHigh);
        highestScore.text = "Highest Score: " + high;
    }

    public void SetPlayGame()=> SceneManager.LoadScene(1);
    public void QuitGame()=> Application.Quit();

   
}
