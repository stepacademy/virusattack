using System.Collections.Generic;
using UnityEngine;
using Assets.VirusAttackSource.AMVCC;


namespace Assets.VirusAttackSource.Game.Models {

    using BattleField;
    using Spawner;
    using Utilities;

    [AddComponentMenu("Virus-Attack/LevelModel")]
    public sealed class LevelModel : Model<VirusAttack> {

        private BattleFieldModel _battleField;
        public  BattleFieldModel BattleField { get { return _battleField = Assert(_battleField); } }

        private BaseModel _base;
        public  BaseModel Base { get { return _base = Assert(_base); } }

        private SpawnerModel _spawner;
        public  SpawnerModel Spawner { get { return _spawner = Assert(_spawner); } }

        [SerializeField] private List<Wave> _waves;

        private void RemoveAllEmpty() {
            foreach (var wave in _waves)
                wave.LevelEnemiesTypes.RemoveAll(x => x.Prefab == null || x.Count == 0);
            _waves.RemoveAll(x => x.LevelEnemiesTypes.Count == 0);
        }

        internal void GenerateBattleField() {
            Base.Generate();
            BattleField.Generate();
        }

        internal void StartEnemiesSpawn() {

            RemoveAllEmpty();

            if (_waves.Count > 0) {
                Spawner.Waves = _waves;
                StartCoroutine(Spawner.SpawnNextWave());                
            }

        }
    }
}