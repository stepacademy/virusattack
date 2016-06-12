using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.VirusAttackSource.Game {

    using Utilities;

    [Serializable]
    public sealed class Wave {

        public float SpawnInterval;
        public List<PrefabCountPair> LevelEnemiesTypes;
    }
}