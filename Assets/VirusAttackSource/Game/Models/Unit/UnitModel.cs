using UnityEngine;
using Assets.VirusAttackSource.AMVCC;


namespace Assets.VirusAttackSource.Game.Models.Unit {

    public enum UnitType { Ally, Enemy }

    [AddComponentMenu("Virus-Attack Source/Models/Unit/UnitModel")]
    public sealed class UnitModel : Model<VirusAttack> {

        private GameObject unitPrefab;        

        private string _name;
        private float  _health;
        private float  _damage;
        private float  _attackSpeed;

        public UnitType    Type;

        private void Start() {

        }
        private void Update() {
            app.view.Unit.OnAttack();
        }
    }
}