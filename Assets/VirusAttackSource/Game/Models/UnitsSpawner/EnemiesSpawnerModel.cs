using System.Collections.Generic;
using UnityEngine;
using Assets.VirusAttackSource.AMVCC;


namespace Assets.VirusAttackSource.Game.Models.UnitsSpawner {

    using Utilities;

    [AddComponentMenu("Virus-Attack Source/EnemySpawner/EnemySpawnerModel")]
    public sealed class EnemiesSpawnerModel : Model<VirusAttack> {

        private float lastSpawnTime;

        [SerializeField] private float _spawnInterval;

        [SerializeField] private List<PrefabCountPair> LevelAlliesTypes;
        [SerializeField] private List<PrefabCountPair> LevelEnemiesTypes;

        private void RemoveAllEmpty() {

            LevelAlliesTypes.RemoveAll (x => x.Prefab == null || x.Count == 0);
            LevelEnemiesTypes.RemoveAll(x => x.Prefab == null || x.Count == 0);

        }

        private void SpawnAuto() {

            if (Time.time - lastSpawnTime > _spawnInterval) {

                int countX = app.model.BattleField.CountX;
                int countZ = app.model.BattleField.CountZ;

                int platformIndex = Random.Range(countX * countZ - countX + 1, countX * countZ - 1);
                Transform platform = app.model.BattleField.transform.GetChild(platformIndex);

                int availableEnemyIndex = Random.Range(0, LevelEnemiesTypes.Count);

                SpawnNextAt(platform, LevelEnemiesTypes[availableEnemyIndex].Prefab);

                LevelEnemiesTypes[availableEnemyIndex].Count--;
                lastSpawnTime = Time.time;
            }
        }

        private void Start() {
            RemoveAllEmpty();
        }

        private void Update() {

            if (LevelEnemiesTypes.Count > 0)
                SpawnAuto();

            RemoveAllEmpty();
        }

        internal void SpawnNextAt(Transform platform, GameObject enemyPrefab) {
            GameObject unit = Instantiate(
                        enemyPrefab,
                        new Vector3(
                            platform.position.x,
                            platform.position.y + enemyPrefab.transform.localScale.y / 2,
                            platform.position.z
                            ),
                        Quaternion.identity) as GameObject;
            unit.transform.SetParent(transform);
        }
    }
}