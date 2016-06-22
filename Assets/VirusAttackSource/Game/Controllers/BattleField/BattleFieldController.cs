using UnityEngine;
using Assets.VirusAttackSource.AMVCC;

namespace Assets.VirusAttackSource.Game.Controllers.BattleField {

    using Base;
    using Tracks;
    using Waves;

    [AddComponentMenu("Virus-Attack/BattleField/BattleFieldController")]
    public sealed class BattleFieldController : Controller<VirusAttack> {

        private BaseController   _base;
        private TracksController _tracks;
        private WavesController  _waves;

        public BaseController   Base   { get { return _base   = Assert(_base);   } }
        public TracksController Tracks { get { return _tracks = Assert(_tracks); } }
        public WavesController  Waves  { get { return _waves  = Assert(_waves);  } }

        public override void OnNotification(string p_event, Object p_target, params object[] p_data) {

            switch (p_event) {
                default: break;
            }
        }
    }
}