using System;
using System.Collections.Generic;

namespace Assets.VirusAttackSource.Game {

    using Utilities;

    [Serializable]
    public sealed class Wave {
        
        public List<PrefabCountPair> LevelEnemiesTypes;
        public float SpawnInterval;
        public float WaitForNextWave;

    }
}