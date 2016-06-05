using System.Collections.Generic;
using UnityEngine;
using Assets.VirusAttackSource.AMVCC;


namespace Assets.VirusAttackSource.Game.Models {

    using BattleField;
    using UnitsSpawner;
    using Utilities;

    [AddComponentMenu("Virus-Attack Source/Models/GameModel")]
    public sealed class LevelModel : Model<VirusAttack> {

        private BattleFieldModel _battleField;
        public  BattleFieldModel BattleField { get { return _battleField = Assert(_battleField); } }

        private EnemiesSpawnerModel _unitsSpawner;
        public  EnemiesSpawnerModel UnitsSpawner { get { return _unitsSpawner = Assert(_unitsSpawner); } }

    }
}