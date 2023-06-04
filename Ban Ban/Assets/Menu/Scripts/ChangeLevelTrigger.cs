using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevelTrigger : MonoBehaviour
{
    public enum ChangeLevelType
    {
        GoLevelWaveMode,
        GoLevelSurvivalMode,
        GoMenu
    }

    [SerializeField] private ChangeLevelType type;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switch (type)
            {
                case ChangeLevelType.GoLevelWaveMode:
                    SceneManager.LoadScene(2);
                    break;
                case ChangeLevelType.GoLevelSurvivalMode:
                    SceneManager.LoadScene(3);
                    break;
                case ChangeLevelType.GoMenu:
                    FindObjectOfType<LevelManager>().StartWinGamePanel();
                    break;
            }
        }
    }
}