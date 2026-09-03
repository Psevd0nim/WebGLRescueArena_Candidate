using UnityEngine;

namespace WebGLRescueArena
{
    public sealed class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private int maxHealth = 100;

        private bool _isDead;

        public int CurrentHealth { get; private set; }

        private void Awake() => CurrentHealth = maxHealth;

        public void TakeDamage(int amount)
        {
            if(_isDead)
                return;

            CurrentHealth -= amount;
            GameEvents.RaisePlayerDamaged(amount);
            if (CurrentHealth <= 0)
            {
                GameEvents.RaisePlayerDied();
                _isDead = true;
            }
        }
    }
}
