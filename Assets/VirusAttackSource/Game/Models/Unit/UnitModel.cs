using VirusAttackSource.AMVCC;


namespace VirusAttackSource.Game.Models.Unit {

    public sealed class UnitModel : Model<VirusAttack> {

        public enum Type { Ally, Enemy }

        private string _name;
        private float  _health;
        private float  _damage;
        private float  _attackSpeed;

        //private IAttackStrategy _attackStrategy;

        public Type    UnitType;

        private void Start() { }
        private void Update() {
            //_attackStrategy.Attack(_damage, _attackSpeed);
        }
    }
}