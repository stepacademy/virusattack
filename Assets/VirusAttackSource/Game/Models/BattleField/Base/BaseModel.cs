using UnityEngine;
using Assets.VirusAttackSource.AMVCC;

namespace Assets.VirusAttackSource.Game.Models.BattleField.Base {

    using Utilities;

    [AddComponentMenu("Virus-Attack/BattleField/Base/BaseModel")]
    public sealed class BaseModel : Model<VirusAttack> {

        internal BaseInspector Inspector { get; private set; }

        public GameObject Ground { get; private set; }
        public GameObject Boss   { get; private set; }

        internal BaseModel SetPreset(BaseInspector baseInspector) {
            Inspector = baseInspector;
            return this;
        }

        private Vector3 CalculateProportionalBossScale() {

            Vector3 bossScale       = Inspector.BossPrefab.transform.localScale;
            float   percentageRatio = Inspector.BossPercentageScaleRatio * 0.01f;

            if (bossScale.x > bossScale.z)
                return new ProportionalScaler().ScaleAtX(bossScale, Inspector.BaseXZSize * percentageRatio);
            else
                return new ProportionalScaler().ScaleAtZ(bossScale, Inspector.BaseXZSize * percentageRatio);
        }

        internal void Generate() {

            Spawner spawner = new Spawner();

            Vector3 groundScale    =
                new Vector3(Inspector.BaseXZSize, Inspector.GroundPrefab.transform.localScale.y, Inspector.BaseXZSize);
            Vector3 groundPosition =
                new Vector3(0, groundScale.y * 0.5f, 0);
            Vector3 bossScale      =
                CalculateProportionalBossScale();
            Vector3 bossPosition   =
                new Vector3(groundPosition.x, groundScale.y + bossScale.y * 0.5f, groundPosition.z);

            Ground = spawner.SpawnAtPosition(Inspector.GroundPrefab, groundPosition, transform, "Base Ground");
            Ground.transform.localScale = groundScale;

            Boss = spawner.SpawnAtPosition(Inspector.BossPrefab, bossPosition, transform, "Player Boss");
            Boss.transform.localScale = bossScale;

            Notify("base.instantiate");
        }
    }
}