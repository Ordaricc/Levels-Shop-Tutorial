using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelShop : MonoBehaviour
{
    public TextMeshProUGUI buttonText;

    public bool isLevelUnlocked;
    public int indexOfSceneToLoad;
    public int levelCost;

    private void Awake()
    {
        //check if level was already bought
        if (PlayerPrefs.GetInt("prefLevel" + indexOfSceneToLoad) == 1)
        {
            isLevelUnlocked = true;
            buttonText.text = "Enter Level";
        }
        else
        {
            buttonText.text = "Buy level for: " + levelCost;
        }
    }

    public void OnLevelButtonPress()
    {
        if (isLevelUnlocked)//enter level
        {
            SceneManager.LoadScene(indexOfSceneToLoad);
        }
        else//try buying level
        {
            if (FindObjectOfType<PlayerMoney>().TryRemoveMoney(levelCost))
            {
                //level was bought
                isLevelUnlocked = true;
                PlayerPrefs.SetInt("prefLevel" + indexOfSceneToLoad, 1);
                buttonText.text = "Enter Level";
            }
        }
    }
}