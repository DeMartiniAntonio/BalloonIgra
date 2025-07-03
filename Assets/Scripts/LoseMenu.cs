using UnityEngine;
using UnityEngine.UI;

public class LoseMenu : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject mainMenu;

    public void Play()
    {
        panel.SetActive(false);
        GameManager.Instance.PlayGame();
    }
    public void BackToMenu()
    {
        mainMenu.SetActive(true);
        panel.SetActive(false);
    }
}
