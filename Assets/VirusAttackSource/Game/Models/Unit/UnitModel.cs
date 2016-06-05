using UnityEngine;
using Assets.VirusAttackSource.AMVCC;


namespace Assets.VirusAttackSource.Game.Models.Unit {

    public enum UnitType { Ally, Enemy }

    [AddComponentMenu("Virus-Attack Source/Unit/UnitModel")]
    public sealed class UnitModel : Model<VirusAttack> {             // HARDCODE CLASS

        private GameObject unitPrefab;        

        private string _name;
        private float  _health;
        private float  _damage;
        private float  _attackSpeed;

        public UnitType    Type;

        private void Start() {

        }
        private void Update() {
            if (
                transform.position.z > 12.0f) {
                Destroy(gameObject);
            }
            transform.Translate(0, 0, 1 * Time.deltaTime);

        }
    }
}