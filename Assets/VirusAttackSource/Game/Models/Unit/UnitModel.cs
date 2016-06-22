using UnityEngine;
using Assets.VirusAttackSource.AMVCC;


namespace Assets.VirusAttackSource.Game.Models.Unit {

    [AddComponentMenu("Virus-Attack/Unit/UnitModel")]
    public sealed class UnitModel : Model<VirusAttack> {                                              // HARDCODE CLASS

        // [SerializeField] private float  _health      = 100.0f;
        // [SerializeField] private float  _damage      = 20.0f;
        // [SerializeField] private float  _attackSpeed = 1.0f;

        public int Index { get; set; }

        // private float _positionLimit;

        private void Start() {                                                          // Example appeal to properties
            // _positionLimit = -app.model.BattleField.Base.Boss.transform.localScale.x * 0.5f;
        }

        private void Update() {                                           // Remove this code for impl. check collision

            if (transform.position.y > 10.0f || transform.position.y < -10.0f) {
                Destroy(gameObject);
            }
            //else if (transform.position.x > 10.0f || transform.position.x < -10.0f) {
            //    Destroy(gameObject);
            //}
            //else if (transform.position.z > _positionLimit) {
            //    Destroy(gameObject);
            //}            
            else {
                transform.Translate(0.0f, 0.0f, 1.5f * Time.deltaTime);
            }
        }
    }
}