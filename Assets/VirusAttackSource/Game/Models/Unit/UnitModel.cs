using UnityEngine;
using Assets.VirusAttackSource.AMVCC;


namespace Assets.VirusAttackSource.Game.Models.Unit {

    public enum UnitType { Ally, Enemy }

    [AddComponentMenu("Virus-Attack/Unit/UnitModel")]
    public sealed class UnitModel : Model<VirusAttack> {                                              // HARDCODE CLASS

        private GameObject unitPrefab;        

        private string _name;
        private float  _health;
        private float  _damage;
        private float  _attackSpeed;

        public UnitType    Type;

        private float _positionLimit;

        private void Start() {                                                          // Example appeal to properties
            _positionLimit = -app.model.BattleField.Base.Boss.transform.localScale.x * 0.5f;
        }

        private void Update() {                                           // Remove this code for impl. check collision
            if (transform.position.z > _positionLimit)
                Destroy(gameObject);
            transform.Translate(0.0f, 0.0f, 1.5f * Time.deltaTime);
        }

    }
}