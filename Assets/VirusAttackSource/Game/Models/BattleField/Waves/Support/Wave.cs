using System;
using System.Collections.Generic;

namespace Assets.VirusAttackSource.Game.Models.BattleField.Waves.Support {

    [Serializable]
    public sealed class Wave {

        public float DelayBeforeStart;
        public float SpawnInterval;
        public List<PrefabCountPair> LevelEnemiesTypes;

    }
}