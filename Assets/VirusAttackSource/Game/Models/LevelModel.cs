using System.Collections.Generic;
using UnityEngine;
using Assets.VirusAttackSource.AMVCC;


namespace Assets.VirusAttackSource.Game.Models {

    using BattleField;

    [AddComponentMenu("Virus-Attack Source/LevelModel")]
    public sealed class LevelModel : Model<VirusAttack> {

        private BattleFieldModel _battleField;
        public  BattleFieldModel BattleField { get { return _battleField = Assert(_battleField); } }

        private SpawnerModel _spawner;
        public  SpawnerModel Spawner { get { return _spawner = Assert(_spawner); } }

        [SerializeField] private List<Wave> _waves;

        private void RemoveAllEmpty() {
            foreach (var wave in _waves)
                wave.LevelEnemiesTypes.RemoveAll(x => x.Prefab == null || x.Count == 0);
            _waves.RemoveAll(x => x.LevelEnemiesTypes.Count == 0);
        }

        internal void GenerateBattleField() {
            BattleField.Generate();
        }

        internal void NextWave() {

            RemoveAllEmpty();

            if (_waves != null && _waves.Count > 0) {                
                StartCoroutine_Auto(Spawner.SpawnEnemiesWave(_waves[0]));
                Log("Next wave start\nSuccess!");
                _waves.RemoveAll(x => x.LevelEnemiesTypes.Count == 0);
            }            
        }
    }
}