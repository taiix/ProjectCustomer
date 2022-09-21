using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionMenu;
    public GameObject manualMenu;
    public GameObject creditsMenu;
    public GameObject mainText;
    public GameObject optionText;
    public GameObject manualText;
    public GameObject creditsText;
    public void OptionMenu()
    {
        mainMenu.SetActive(false);
        mainText.SetActive(false);
        creditsMenu.SetActive(false);
        creditsText.SetActive(false);
        manualMenu.SetActive(false);
        manualText.SetActive(false);
        optionMenu.SetActive(true);
        optionText.SetActive(true);
    }

    public void ManualMenu()
    {
        mainMenu.SetActive(false);
        mainText.SetActive(false);
        creditsMenu.SetActive(false);
        creditsText.SetActive(false);
        manualMenu.SetActive(true);
        manualText.SetActive(true);
        optionMenu.SetActive(false);
        optionText.SetActive(false);
    }

    public void CreditsMenu()
    {
        mainMenu.SetActive(false);
        mainText.SetActive(false);
        creditsMenu.SetActive(true);
        creditsText.SetActive(true);
        manualMenu.SetActive(false);
        manualText.SetActive(false);
        optionMenu.SetActive(false);
        optionText.SetActive(false);
    }

    public void MainMenu()
    {
        mainMenu.SetActive(true);
        mainText.SetActive(true);
        creditsMenu.SetActive(false);
        creditsText.SetActive(false);
        manualMenu.SetActive(false);
        manualText.SetActive(false);
        optionMenu.SetActive(false);
        optionText.SetActive(false);
    }

    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }
}
