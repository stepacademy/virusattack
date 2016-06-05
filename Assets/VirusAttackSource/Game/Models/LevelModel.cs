using System.Collections.Generic;
using UnityEngine;
using Assets.VirusAttackSource.AMVCC;


namespace Assets.VirusAttackSource.Game.Models {

    using BattleField;
    using Utilities;

    [AddComponentMenu("Virus-Attack Source/Models/GameModel")]
    public sealed class LevelModel : Model<VirusAttack> {
        
        [SerializeField] private List<PrefabCountPair> _levelAlliesTypesCount;
        [SerializeField] private List<PrefabCountPair> _levelEnemiesTypesCount;

        private BattleFieldModel _battleField;
        public  BattleFieldModel BattleField { get { return _battleField = Assert(_battleField); } }

    }
}