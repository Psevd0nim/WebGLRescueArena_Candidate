using TMPro;
using UnityEngine;

namespace WebGLRescueArena
{
    public sealed class HUDController : MonoBehaviour
    {
        [SerializeField] private TMP_Text healthText;
        [SerializeField] private TMP_Text scoreText;
        [SerializeField] private TMP_Text enemyCountText;
        [SerializeField] private TMP_Text timerText;

        private int _lastScore = int.MinValue;
        private int _lastHealth = int.MinValue;
        private int _lastEnemies = int.MinValue;
        private int _lastElapsedTenths = int.MinValue;

        public void Refresh(int score, int health, int enemies, float elapsed)
        {
            if (_lastHealth != health)
            {
                //healthText.text = "HP: " + health;
                healthText.SetText("HP: {0}", health);
                _lastHealth = health;
            }
            if (_lastScore != score)
            {
                //scoreText.text = "Score: " + score;
                scoreText.SetText("Score: {0}", score);
                _lastScore = score;
            }
            if (_lastEnemies != enemies)
            {
                //enemyCountText.text = "Enemies: " + enemies;
                enemyCountText.SetText("Enemies: {0}", enemies);
                _lastEnemies = enemies;
            }

            int elapsedTenths = Mathf.FloorToInt(elapsed * 10f);
            if (_lastElapsedTenths != elapsedTenths)
            {
                //timerText.text = "Time: " + elapsed.ToString("0.0");
                timerText.SetText("Time: {0:0.0}", elapsed);
                _lastElapsedTenths = elapsedTenths;
            }
        }
    }
}
