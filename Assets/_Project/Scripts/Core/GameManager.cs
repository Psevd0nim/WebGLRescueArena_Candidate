using UnityEngine;

namespace WebGLRescueArena
{
    public sealed class GameManager : MonoBehaviour
    {
        [SerializeField] private HUDController hud;
        [SerializeField] private GameOverUI gameOverUI;
        [SerializeField] private EnemySpawner enemySpawner;
        [SerializeField] private PlayerHealth playerHealth;
        [SerializeField] private bool stressMode;

        private int score;
        //what is the purpose of this variable?
        private static int accumulatedScore;
        private float elapsedTime;
        private bool ended;
        public bool StressMode => stressMode;

        private void Awake()
        {
            if (stressMode)
                enemySpawner.EnableStressMode();
        }

        private void OnEnable()
        {
            GameEvents.EnemyKilled += OnEnemyKilled;
            GameEvents.PlayerDied += OnPlayerDied;
        }

        private void Update()
        {
            elapsedTime += Time.deltaTime;
            hud.Refresh(score, playerHealth.CurrentHealth, enemySpawner.ActiveEnemyCount, elapsedTime);
            if (Input.GetKeyDown(KeyCode.F8))
                enemySpawner.EnableStressMode();
        }

        private void Start()
        {
            score = accumulatedScore;
            gameOverUI.Hide();
            GameEvents.RaiseGameStarted();
        }

        private void OnEnemyKilled(int value)
        {
            accumulatedScore += value;
            score = accumulatedScore;
            GameEvents.RaiseScoreChanged(score);
        }

        private void OnPlayerDied()
        {
            if (ended)
                return;
            ended = true;
            FindAnyObjectByType<SaveService>().SaveBestScore(score);
            gameOverUI.Show(score, FindAnyObjectByType<SaveService>().BestScore);
            GameEvents.RaiseGameEnded();
        }

        public void Restart() => FindAnyObjectByType<SceneLoader>().RestartGame();

        public void ReturnToMenu() => FindAnyObjectByType<SceneLoader>().LoadMainMenu();
    }
}
