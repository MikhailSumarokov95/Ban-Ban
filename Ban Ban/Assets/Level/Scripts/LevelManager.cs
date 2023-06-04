using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using static StateGameManager;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject winGamePanel;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject waveEndPanel;
    [SerializeField] private GameObject lossPanel;
    [SerializeField] private GameObject[] shopBanners;
    private PlatformManager _platformManager;
    private bool _isWinGame;
    private GameMode _gameMode;

    private void OnEnable()
    {
        _gameMode = FindObjectOfType<GameMode>();
        GameMode.OnWavesOver += WinGame;
        GameMode.OnWaveEnd += EndWave;
    }

    private void OnDisable()
    {
        GameMode.OnWavesOver -= WinGame;
        GameMode.OnWaveEnd -= EndWave;
    }

    private void Start()
    {
        _platformManager = FindObjectOfType<PlatformManager>();
        OnPause(false);
        StateGame = State.Game;
        _gameMode.StartNewWave();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && StateGame == State.Game)
            SetActivePausePanel(true);
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        OnPause(false);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        OnPause(false);
    }

    public void Did()
    {
        OnPause(true);
        StateGame = State.Pause;
        lossPanel.SetActive(true);
        shopBanners[Random.Range(0, shopBanners.Length)].gameObject.SetActive(true);
    }

    public void Respawn()
    {
        OnPause(false);
        StateGame = State.Game;
        lossPanel.SetActive(false);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Life>().Respawn();
    }

    public void SetActivePausePanel(bool value)
    {
        StateGame = value ? State.Pause : State.Game;
        pausePanel.SetActive(value);
        OnPause(value);
    }

    public void TryRewardRespawn()
    {
        GSConnect.ShowRewardedAd(GSConnect.ContinueReward);
    }

    public void StartWinGamePanel()
    {
        if (!_isWinGame) return;
        GSConnect.ShowMidgameAd();
        SetActivePausePanel(false);
        SetActiveWinPanel(true);
        Level.NextLevel();
        FindObjectOfType<BattlePassRewarder>(true).RewardPerLevel();
    }

    public void SetActiveWaveEndPanel(bool value)
    {
        StateGame = value ? State.WaveEnd : State.Game;
        waveEndPanel.SetActive(value);
        OnPause(value);
        if (!value) _gameMode.StartNewWave();
    }

    private void WinGame()
    {
        _isWinGame = true;
        StartWinGamePanel();
    }

    private void SetActiveWinPanel(bool value)
    {
        StateGame = value ? State.GameOver : State.Game;
        winGamePanel.SetActive(value);
        shopBanners[Random.Range(0, shopBanners.Length)].gameObject.SetActive(true);
        OnPause(value);
    }

    private void EndWave()
    {
        GSConnect.ShowMidgameAd();
        SetActivePausePanel(false);
        SetActiveWaveEndPanel(true);
    }

    private void OnPause(bool value)
    {
        Time.timeScale = value ? 0 : 1;
        if (!_platformManager.IsMobile) Cursor.lockState = value ? CursorLockMode.None : CursorLockMode.Locked;
    }
}