using System.Collections.Generic;
using UnityEngine;
using Assets.VirusAttackSource.AMVCC;


namespace Assets.VirusAttackSource.Game.Models {

    using BattleField;
    using Enemies;

    [AddComponentMenu("Virus-Attack Source/LevelModel")]
    public sealed class LevelModel : Model<VirusAttack> {

        private BattleFieldModel _battleField;
        public  BattleFieldModel BattleField { get { return _battleField = Assert(_battleField); } }

        private SpawnerModel _spawner;
        public  SpawnerModel Spawner { get { return _spawner = Assert(_spawner); } }

        private EnemiesModel _enemies;
        public  EnemiesModel Enemies { get { return _enemies = Assert(_enemies); } }

        [SerializeField] private List<Wave> _waves;

        private void RemoveAllEmpty() {
            foreach (var wave in _waves)
                wave.LevelEnemiesTypes.RemoveAll(x => x.Prefab == null || x.Count == 0);
            _waves.RemoveAll(x => x.LevelEnemiesTypes.Count == 0);
        }

        internal void GenerateBattleField() {
            BattleField.Generate();
        }

        internal void StartEnemiesWaves() {

            RemoveAllEmpty();

            int countX = app.model.BattleField.CountX;
            int countZ = app.model.BattleField.CountZ;

            int currentWave = 0;
            //int currentEnemyType = 1;
            //int currentEnemyIndex = 1;

            
            float lastSpawnTime = 0.0f;
            if (app.model.Enemies.Enemies == null)
                app.model.Enemies.Enemies = new List<GameObject>();

            while (_waves[0] != null && _waves[0].LevelEnemiesTypes.Count > 0) {
                currentWave++;
                Log("Wave: " + currentWave + "\nStarted!");
                
                while (_waves[0].LevelEnemiesTypes[0] != null && _waves[0].LevelEnemiesTypes[0].Count > 0) {
                    //if (Time.time - lastSpawnTime > _waves[0].SpawnInterval) {

                        int platformIndex  = Random.Range(countX * countZ - countX + 1, countX * countZ - 1);
                        Transform platform = BattleField.transform.GetChild(platformIndex);

                        Enemies.Enemies.Add(
                            Spawner.SpawnAtGameObject(
                                _waves[0].LevelEnemiesTypes[0].Prefab, platform, Enemies.transform));

                        _waves[0].LevelEnemiesTypes[0].Count--;

                        lastSpawnTime = Time.time;
                    //RemoveAllEmpty();
                    //}
                    RemoveAllEmpty();
                }
                //RemoveAllEmpty();
            }

        }
    }
}