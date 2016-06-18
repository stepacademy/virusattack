using System.Text;
using System.Collections.Generic;
using UnityEngine;
using Assets.VirusAttackSource.AMVCC;

namespace Assets.VirusAttackSource.Game.Models.BattleField {
    
    [AddComponentMenu("Virus-Attack/BattleField/BattleFieldModel")]
    public sealed class BattleFieldModel : Model<VirusAttack> {

        public float SizeX { get; private set; }
        public float SizeZ { get; private set; }

        public List<List<GameObject>> PlatformsWall   { get; private set; }
        public List<List<GameObject>> PlatformsGround { get; private set; }
        public List<GameObject>       Macrofags       { get; private set; }

        public int       CountX = 6;
        public int       CountZ = 14;
        [SerializeField] private bool   _setPositionAtWorldCenter = true;

        [SerializeField] private GameObject _platformGroundPrefab = null;
        [SerializeField] private GameObject _platformWallPrefab   = null;
        [SerializeField] private GameObject _defendersWallPrefab  = null;

        private void FixCount() {
            if (CountX < 3) CountX = 3;
            if (CountZ < 3) CountZ = 3; 
        }

        private Vector3 CalculatePlatformPosition(GameObject platformPrefab, int platformNumberX, int platformNumberZ) {
            return new Vector3(
                platformPrefab.transform.localScale.x *  platformNumberX + platformPrefab.transform.localScale.x * 0.5f,
                platformPrefab.transform.localScale.y *  0.5f,
                platformPrefab.transform.localScale.z * -platformNumberZ - platformPrefab.transform.localScale.z * 0.5f
                );
        }

        private string GenerateCurrentPlatformName(string platformPrefabTag, int platformNumberX, int platformNumberZ) {
            return new StringBuilder("Platform")
                        .Append(" | z:").Append(platformNumberZ).Append(" | x:").Append(platformNumberX)
                        .Append(" | tag:").Append(platformPrefabTag).ToString();
        }

        private void SetPositionAtWorldCenter() {

            SizeX = _platformGroundPrefab.transform.localScale.x * CountX;
            SizeZ = _platformGroundPrefab.transform.localScale.z * CountZ;

            transform.position = new Vector3(SizeX * -0.5f, 0, SizeZ * 0.5f);
        }

        private void FixPosition() {
            SizeX = _platformGroundPrefab.transform.localScale.x * CountX;
            transform.position = new Vector3(SizeX * -0.5f, 0, app.model.Base.Ground.transform.localScale.z * -0.5f);
        }

        internal void Generate() {

            FixCount();

            PlatformsWall = new List<List<GameObject>>(CountZ);
            PlatformsGround = new List<List<GameObject>>(CountZ);

            Macrofags = new List<GameObject>(CountX - 2);

            for (int z = 0; z < CountZ; ++z) {

                PlatformsWall.Add(new List<GameObject>(2));
                PlatformsGround.Add(new List<GameObject>(CountX - 2));

                for (int x = 0; x < CountX; ++x) {

                    if (x == 0 || x == CountX - 1) {
                        PlatformsWall[z].Add(app.model.Spawner.SpawnAtPosition(
                            _platformWallPrefab, CalculatePlatformPosition(_platformWallPrefab, x, z),
                            transform, GenerateCurrentPlatformName("Wall", x, z)));
                    }
                    else {
                        PlatformsGround[z].Add(app.model.Spawner.SpawnAtPosition(
                            _platformGroundPrefab, CalculatePlatformPosition(_platformGroundPrefab, x, z),
                            transform, GenerateCurrentPlatformName("Ground", x, z)));

                        if (z == 0) {
                            Macrofags.Add(app.model.Spawner.SpawnAtGameObject(
                                _defendersWallPrefab, PlatformsGround[z][x - 1].transform,
                                PlatformsGround[z][x - 1].transform, "Macrofag"));
                        }
                    }
                }
            }

            //if (_setPositionAtWorldCenter)
            //    SetPositionAtWorldCenter();
            FixPosition();

            app.controller.BattleField.Notify("ground.instantiate");
        }
    }
}