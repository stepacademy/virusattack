using System.Collections.Generic;
using UnityEngine;
using Assets.VirusAttackSource.AMVCC;

namespace Assets.VirusAttackSource.Game {

    using Models;
    using Views;
    using Controllers;
    using Utilities;
    
    [AddComponentMenu("Virus-Attack Source/VirusAttack")]
    public sealed class VirusAttack : BaseApplication<LevelModel, LevelView, LevelController> {

        [SerializeField] private Player User;
        [SerializeField] private List<string> Levels;

        // Be sure to use the previously Start () from .base
        protected override void Start() {
            base.Start();
        }

        // Update is called once per frame
        private void Update() { }
    }
}