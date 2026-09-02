using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace WebGLRescueArena
{
    public sealed class EnemyManager : MonoBehaviour
    {
        [SerializeField] private Transform player;
        [SerializeField] private bool _enableEnemyTickPipeline;

        private readonly List<EnemyController> enemies = new List<EnemyController>();

        public int Count => enemies.Count;

        public void Register(EnemyController enemy) => enemies.Add(enemy);

        public void Unregister(EnemyController enemy) => enemies.Remove(enemy);

        private void Update()
        {
            if (_enableEnemyTickPipeline)
            {
                List<EnemyController> living = enemies
                .Where(enemy => enemy != null)
                .OrderBy(enemy => Vector3.SqrMagnitude(enemy.transform.position - player.position))
                .ToList();

                for (int index = 0; index < living.Count; index++)
                    living[index].Tick();
            }
        }
    }
}
