using System.Collections.Generic;
using UnityEngine;
using Assets.VirusAttackSource.AMVCC;


namespace Assets.VirusAttackSource.Game.Models {

    using Utilities;

    [AddComponentMenu("Virus-Attack Source/Models/GameModel")]
    public sealed class LevelModel : Model<VirusAttack> {

        [SerializeField] private uint   _levelId;
        [SerializeField] private string _levelName;

        [SerializeField] private List<PrefabCountPair> _levetEnemiesTypesCount;

    }

}