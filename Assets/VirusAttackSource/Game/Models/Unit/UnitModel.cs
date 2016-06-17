using UnityEngine;
using Assets.VirusAttackSource.AMVCC;


namespace Assets.VirusAttackSource.Game.Models.Unit {

    public enum UnitType { Ally, Enemy }

    [AddComponentMenu("Virus-Attack Source/Unit/UnitModel")]
    public sealed class UnitModel : Model<VirusAttack> {                                              // HARDCODE CLASS

        private GameObject unitPrefab;        

        private string _name;
        private float  _health;
        private float  _damage;
        private float  _attackSpeed;

        public UnitType    Type;

        private float _positionLimit;

        private void Start() {                                                          // Example appeal to properties

            float battleFieldEdgeZ    = app.model.BattleField.SizeZ * 0.5f;
            float macrofagScaleZ      = app.model.BattleField.Macrofags[0].transform.localScale.z;
            float currentPrefabScaleZ = transform.localScale.z;
            _positionLimit = battleFieldEdgeZ - macrofagScaleZ - currentPrefabScaleZ * 0.5f;
        }

        private void Update() {                                           // Remove this code for impl. check collision

            if (transform.position.z > _positionLimit) {
                Destroy(gameObject);
                // Log(transform.name + " destroyed at limit: " + _positionLimit + '\n');
            }
            transform.Translate(0.0f, 0.0f, 1.0f * Time.deltaTime);
        }
    }
}