using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionMenu;
    public GameObject manualMenu;
    public GameObject creditsMenu;
public void OptionMenu(){
mainMenu.SetActive(false);
optionMenu.SetActive(true);
}

public void ManualMenu(){
mainMenu.SetActive(false);
manualMenu.SetActive(true);
}

public void CreditsMenu(){
mainMenu.SetActive(false);
creditsMenu.SetActive(true);
}

public void MainMenu(){
mainMenu.SetActive(true);
optionMenu.SetActive(false);
manualMenu.SetActive(false);
creditsMenu.SetActive(false);
}

public void StartButton(){
SceneManager.LoadScene(1);
}
}
