using UnityEngine;
using Assets.VirusAttackSource.AMVCC;

namespace Assets.VirusAttackSource.Game.Views.Unit {

    [AddComponentMenu("Virus-Attack/Unit/UnitCollisionView")]
    public sealed class UnitCollisionView : CollisionView<VirusAttack> {

        private void Start() {
            notification = name;
        }

        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Enemy" && this.tag == "Ally")
                Notify("collision.enter");
        }

    }
}