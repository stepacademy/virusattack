using UnityEngine;
using Assets.VirusAttackSource.AMVCC;
using System.Collections;
using System.Collections.Generic;


namespace Assets.VirusAttackSource.Game.Models.Unit {
    using Unit.Support;
    using Models;
    [AddComponentMenu("Virus-Attack/Unit/UnitModel")]
    public sealed class UnitModel : Model<VirusAttack> {                                              // HARDCODE CLASS

        
        [SerializeField] private float  _health      = 100.0f;
        [SerializeField] private float  _damage      = 20.0f;
        [SerializeField] private float  _attackSpeed = 1.0f;
        private float _attakTimer;
        [SerializeField] private float _attackDistans = 15.0f;
        public int TrackIndex { get; set; }
        [SerializeField] private AttackType _attackType;
        public bool IsAttack { get; set; }
                

        public int Index { get; set; }

        public float Health
        {
            get
            {
                return _health;
            }

            set
            {
                _health = value;
            }
        }
        

        // private float _positionLimit;

        private void Start() {                                                          // Example appeal to properties
            // _positionLimit = -app.model.BattleField.Base.Boss.transform.localScale.x * 0.5f;
            _attakTimer = _attackSpeed;
        }

        private void Update() {                                           // Remove this code for impl. check collision

            if (this.tag == "Enemy")
            {
                if (transform.position.y > 10.0f || transform.position.y < -10.0f)
                {
                    Destroy(gameObject);
                }
                //else if (transform.position.x > 10.0f || transform.position.x < -10.0f) {
                //    Destroy(gameObject);
                //}
                //else if (transform.position.z > _positionLimit) {
                //    Destroy(gameObject);
                //}            
                else
                {
                    transform.Translate(0.0f, 0.0f, 1.5f * Time.deltaTime);
                }
            }

            if(_health <= 0)
            {
                Destroy(gameObject);
            }

            if (IsAttack)
            {
                Attack();
                //IsAttack = false;
            }

            }

        void Attack()
        {
            
            if (_attackType == AttackType.contactRadius)
            {
                List<GameObject> Enemy = app.model.BattleField.Waves.Enemy;
                
                for (int i = 0; i < Enemy.Count; i++)
                {
                    float dist = Vector3.Distance(this.transform.position, Enemy[i].transform.position);
                    if (dist <= _attackDistans)
                    {
                        Enemy[i].GetComponent<UnitModel>().Health -= _damage;
                        Enemy.RemoveAt(i);
                    }
                }

                Destroy(gameObject);
            }
        }

        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Enemy" && this.tag == "Ally")
                IsAttack = true;
               // Notify("collision.enter");
        }

    }
}