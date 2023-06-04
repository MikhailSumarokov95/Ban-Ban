using UnityEngine;

public class StateGameManager : MonoBehaviour
{
    public enum State
    {
        Game,
        Pause,
        WaveEnd,
        GameOver
    }

    [SerializeField] private static State _stateGame = State.Game;
    public static State StateGame { get { return _stateGame; } set { _stateGame = value; } }
}
