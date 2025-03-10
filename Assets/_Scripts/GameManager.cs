using TMPro;
using UnityEngine;

public class GameManager : SingletonMonoBehavior<GameManager>
{
    [SerializeField] private int score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private CoinCounterUI coinCounter; 
    [SerializeField] private InputManager inputManager;
    [SerializeField] private GameObject settingsMenu;

    private bool isSettingsMenuActive;
    public bool IsSettingsMenuActive => isSettingsMenuActive;
    protected override void Awake()
    {
        base.Awake();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        inputManager.OnSettingsMenu.AddListener(ToggleSettingsMenu);
        DisableSettingsMenu();
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = $"Score: {score}";
        coinCounter.UpdateScore(score); 
    }

    private void ToggleSettingsMenu()
{
    if (isSettingsMenuActive)
        DisableSettingsMenu();
    else
        EnableSettingsMenu();
}

private void EnableSettingsMenu()
{
    Time.timeScale = 0f;
    settingsMenu.SetActive(true);
    
    Cursor.lockState = CursorLockMode.None;
    Cursor.visible = true;

    isSettingsMenuActive = true;
}

public void DisableSettingsMenu()
{
    Time.timeScale = 1f;
    settingsMenu.SetActive(false);
    
    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;

    isSettingsMenuActive = false;
}

public void QuitGame()
{
#if UNITY_Editor
    EditorApplication.isPlaying = false; 
#else
    Application.Quit(); 
#endif
}
}
