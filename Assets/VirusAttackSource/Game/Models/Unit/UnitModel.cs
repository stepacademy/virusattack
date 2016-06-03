using UnityEngine;
using VirusAttackSource.AMVCC;


namespace VirusAttackSource.Game.Models.Unit {

    [AddComponentMenu("Virus-Attack Source/Models/Unit/UnitModel")]
    public sealed class UnitModel : Model<VirusAttack> {

        private GameObject unitPrefab;

        public enum Type { Ally, Enemy }

        private string _name;
        private float  _health;
        private float  _damage;
        private float  _attackSpeed;

        public Type    UnitType;

        private void Start() {

        }
        private void Update() {
            app.view.Unit.OnAttack();
        }
    }
}