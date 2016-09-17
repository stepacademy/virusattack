using UnityEngine;
using Assets.VirusAttackSource.AMVCC;
using System.Collections.Generic;


namespace Assets.VirusAttackSource.Game.Models.Unit {

    using Support;

    [AddComponentMenu("Virus-Attack/Unit/UnitModel")]
    public sealed class UnitModel : Model<VirusAttack> {

        // private float      _attackTimer;                      // <- field is assigned but its value is never used

        [SerializeField] private float _health        /* = 100.0f*/;
        [SerializeField] private float _damage        /* = 20.0f*/;
        [SerializeField] private float _attackSpeed    /*= 1.0f*/;   // <- field is assigned but its value is never used
        [SerializeField] private float _attackDistance /*= 20.0f*/;
        [SerializeField] private AttackType _attackType;

        private float attackTimer;
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
             attackTimer = _attackSpeed;
        }

        private void Update() {

            if (attackTimer > 0)
                attackTimer -= Time.deltaTime;
            else
            {
                IsAttack = true;
                attackTimer = _attackSpeed;
            }
             
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

            if (Health <= 0) {
                Destroy(gameObject);
            }

            //if (_attackType == AttackType.Straight)
            //{
            //    if (IsAttack)
            //    {
            //        RaycastHit hit;
            //        Ray ray = new Ray(transform.position, Vector3.up);
            //        if (Physics.Raycast(ray, out hit, _attackDistance))
            //        {
            //            if (tag == "Ally" && hit.collider.tag == "Enemy" || tag == "Enemy" && hit.collider.tag == "Ally")
            //            {
            //                hit.collider.GetComponent<UnitModel>().Health -= _damage;
            //            }
            //        }

            //        IsAttack = false;
            //    }

            //}
        }
                

        void OnCollisionEnter(Collision collision)
        {

            if ((collision.gameObject.tag == "Enemy" && tag == "Ally") || collision.gameObject.tag == "Ally" && tag == "Enemy")
            {

                if (_attackType == AttackType.ContactRadius)
                {


                    GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

                    int i = 0;

                    while (enemies[i])
                    {
                        enemies[i].GetComponent<UnitModel>().Health -= _damage;
                        i++;
                    }

                    //List<GameObject> Enemy = app.model.BattleField.Waves.Enemy;

                    //for (int i = 0; i < Enemy.Count; i++)
                    //{

                    //    float dist = Vector3.Distance(transform.position, Enemy[i].transform.position);

                    //    if (dist <= _attackDistance)
                    //    {
                    //        UnitModel um = Enemy[i].GetComponent<UnitModel>();
                    //        Enemy[i].GetComponent<UnitModel>().Health -= _damage;
                    //        Enemy.RemoveAt(i);
                    //    }
                    //}
                    //Destroy(gameObject);
                }

                else if (_attackType == AttackType.Contact)
                {
                    collision.gameObject.GetComponent<UnitModel>().Health -= _damage;
                }
                // Notify("collision.enter");
            }
        }
    }
}