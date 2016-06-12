using Assets.VirusAttackSource.AMVCC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.VirusAttackSource.Game.Models.Enemies {

    public sealed class EnemiesModel : Model<VirusAttack> {

        [NonSerialized] public List<GameObject> Enemies;
    }
}