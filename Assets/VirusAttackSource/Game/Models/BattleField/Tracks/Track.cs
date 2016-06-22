using System.Collections.Generic;
using UnityEngine;
using Assets.VirusAttackSource.AMVCC;


namespace Assets.VirusAttackSource.Game.Models.BattleField.Tracks {

    public sealed class Track : Model<VirusAttack> {

        public List<List<GameObject>> PlatformsWall   { get; set; }
        public List<List<GameObject>> PlatformsGround { get; set; }
        public List<GameObject>       Macrofags       { get; set; }
    }
}