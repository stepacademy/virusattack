using UnityEngine;
using Assets.VirusAttackSource.AMVCC;

namespace Assets.VirusAttackSource.Game {

    using Models;
    using Views;
    using Controllers;

    [AddComponentMenu("Virus-Attack Source/VirusAttack")]
    public sealed class VirusAttack : BaseApplication<LevelModel, LevelView, LevelController> {

        // Use Start() from .base

        // Update is called once per frame
        private void Update() { }

    }

}