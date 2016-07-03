using UnityEngine;
using Assets.VirusAttackSource.AMVCC;
using System.Collections.Generic;


namespace Assets.VirusAttackSource.Game.Models.Unit {

    using Support;

    [AddComponentMenu("Virus-Attack/Unit/UnitModel")]
    public sealed class UnitModel : Model<VirusAttack> {

        // private float      _attackTimer;                      // <- field is assigned but its value is never used

        [SerializeField] private float _health         = 100.0f;
        [SerializeField] private float _damage         = 20.0f;
        [SerializeField] private float _attackSpeed    = 1.0f;   // <- field is assigned but its value is never used
        [SerializeField] private float _attackDistance = 15.0f;
        [SerializeField] private AttackType _attackType;

        public int  TrackIndex { get; set; }
        public bool IsAttack   { get; set; }        

        public int Index { get; set; }

        public float Health {
            get {
                return _health;
            }
            set {
                _health = value;
            }
        }

        private void Start() {
            //_attackTimer = _attackSpeed;
        }

        private void Update() {

            if (tag == "Enemy") {
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

            if (_health <= 0) {
                Destroy(gameObject);
            }

            if (IsAttack) {
                Attack();
                //IsAttack = false;
            }
        }

        void Attack() {

            if (_attackType == AttackType.ContactRadius) {
                List<GameObject> Enemy = app.model.BattleField.Waves.Enemy;

                for (int i = 0; i < Enemy.Count; i++) {

                    float dist = Vector3.Distance(transform.position, Enemy[i].transform.position);

                    if (dist <= _attackDistance) {
                        Enemy[i].GetComponent<UnitModel>().Health -= _damage;
                        Enemy.RemoveAt(i);
                    }
                }
                Destroy(gameObject);
            }
        }

        void OnCollisionEnter(Collision collision) {
            if (collision.gameObject.tag == "Enemy" && tag == "Ally")
                IsAttack = true;
            Notify("collision.enter");
        }
    }
}