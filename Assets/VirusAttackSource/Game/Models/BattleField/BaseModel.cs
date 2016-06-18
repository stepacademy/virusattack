using UnityEngine;
using Assets.VirusAttackSource.AMVCC;

namespace Assets.VirusAttackSource.Game.Models.BattleField {

    [AddComponentMenu("Virus-Attack/Base/BaseModel")]
    public sealed class BaseModel : Model<VirusAttack> {
        
        public GameObject Ground { get; private set; }
        public GameObject Boss   { get; private set; }
        
        [SerializeField] private float      _groundXZSize           = 6;
        [SerializeField] private float      _bossRelativePercentage = 67;
        [SerializeField] private GameObject _groundPrefab           = null;
        [SerializeField] private GameObject _bossPrefab             = null;


        private Vector3 CalculateProportionalBossScale() {

            double bossSizeX = _bossPrefab.transform.localScale.x;
            double bossSizeY = _bossPrefab.transform.localScale.y;
            double bossSizeZ = _bossPrefab.transform.localScale.z;

            double oldMaxHorizontal = bossSizeX > bossSizeZ ? bossSizeX : bossSizeZ;
            double newMaxHorizontal = _groundXZSize * 0.01f * _bossRelativePercentage;

            double ratio = oldMaxHorizontal > newMaxHorizontal
                ? oldMaxHorizontal / newMaxHorizontal
                : newMaxHorizontal / oldMaxHorizontal;

            return new Vector3((float)(bossSizeX * ratio), (float)(bossSizeY * ratio), (float)(bossSizeZ * ratio));
        }

        internal void Generate() {

            Vector3 groundScale    = new Vector3(_groundXZSize, _groundPrefab.transform.localScale.y, _groundXZSize);
            Vector3 groundPosition = new Vector3(0, groundScale.y * 0.5f, 0);
            Vector3 bossScale      = CalculateProportionalBossScale();
            Vector3 bossPosition   = new Vector3(groundPosition.x, groundScale.y + bossScale.y * 0.5f, groundPosition.z);

            Ground = app.model.Spawner.SpawnAtPosition(_groundPrefab, groundPosition, transform, "Base Ground");
            Ground.transform.localScale = groundScale;

            Boss = app.model.Spawner.SpawnAtPosition(_bossPrefab, bossPosition, transform, "Player Boss");
            Boss.transform.localScale = bossScale;

            Log("base.instantiate");
        }
    }
}