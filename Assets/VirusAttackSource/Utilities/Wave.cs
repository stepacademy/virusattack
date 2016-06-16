﻿using System;
using System.Collections.Generic;

namespace Assets.VirusAttackSource.Utilities {

    using Utilities;

    [Serializable]
    public sealed class Wave {

        public float DelayBeforeStart;
        public float SpawnInterval;
        public List<PrefabCountPair> LevelEnemiesTypes;

    }
}