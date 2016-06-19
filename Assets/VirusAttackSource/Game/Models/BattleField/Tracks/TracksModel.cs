using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Assets.VirusAttackSource.AMVCC;


namespace Assets.VirusAttackSource.Game.Models.BattleField.Tracks {

    using Utilities;

    [AddComponentMenu("Virus-Attack/BattleField/Tracks/TracksModel")]
    public sealed class TracksModel : Model<VirusAttack> {

        internal TracksInspector Inspector { get; private set; }

        public float SizeX { get; private set; }
        public float SizeZ { get; private set; }

        public List<List<GameObject>> PlatformsWall   { get; private set; }
        public List<List<GameObject>> PlatformsGround { get; private set; }
        public List<GameObject>       Macrofags       { get; private set; }

        internal TracksModel SetPreset(TracksInspector tracksInspector) {
            Inspector = tracksInspector;
            return this;
        }

        private Vector3 CalculatePlatformPosition(GameObject platformPrefab, int platformNumberX, int platformNumberZ) {
            return new Vector3(
                platformPrefab.transform.localScale.x * platformNumberX + platformPrefab.transform.localScale.x * 0.5f,
                platformPrefab.transform.localScale.y * 0.5f,
                platformPrefab.transform.localScale.z * -platformNumberZ - platformPrefab.transform.localScale.z * 0.5f
                );
        }

        private string GenerateCurrentPlatformName(string platformPrefabTag, int platformNumberX, int platformNumberZ) {
            return new StringBuilder("Platform")
                        .Append(" | z:").Append(platformNumberZ).Append(" | x:").Append(platformNumberX)
                        .Append(" | tag:").Append(platformPrefabTag).ToString();
        }

        private void SetPositionAtWorldCenter() {

            SizeX = Inspector.PlatformGroundPrefab.transform.localScale.x * Inspector.CellsResolutionWidth;
            SizeZ = Inspector.PlatformGroundPrefab.transform.localScale.z * Inspector.CellsResolutionLength;

            transform.position = new Vector3(SizeX * -0.5f, 0, SizeZ * 0.5f);
        }

        private void FixPosition() {
            SizeX = Inspector.PlatformGroundPrefab.transform.localScale.x * Inspector.CellsResolutionWidth;
            transform.position = new Vector3(SizeX * -0.5f, 0, app.model.BattleField.Base.Ground.transform.localScale.z * -0.5f);
        }

        internal void Generate() {

            int CountX = Inspector.CellsResolutionWidth;
            int CountZ = Inspector.CellsResolutionLength;

            Spawner spawner = new Spawner();

            PlatformsWall = new List<List<GameObject>>(CountZ);
            PlatformsGround = new List<List<GameObject>>(CountZ);

            Macrofags = new List<GameObject>(CountX - 2);

            for (int z = 0; z < CountZ; ++z) {

                PlatformsWall.Add(new List<GameObject>(2));
                PlatformsGround.Add(new List<GameObject>(CountX - 2));

                for (int x = 0; x < CountX; ++x) {

                    if (x == 0 || x == CountX - 1) {
                        PlatformsWall[z].Add(spawner.SpawnAtPosition(
                            Inspector.PlatformWallPrefab, CalculatePlatformPosition(Inspector.PlatformWallPrefab, x, z),
                            transform, GenerateCurrentPlatformName("Wall", x, z)));
                    }
                    else {
                        PlatformsGround[z].Add(spawner.SpawnAtPosition(
                            Inspector.PlatformGroundPrefab, CalculatePlatformPosition(Inspector.PlatformGroundPrefab, x, z),
                            transform, GenerateCurrentPlatformName("Ground", x, z)));

                        if (z == 0) {
                            Macrofags.Add(spawner.SpawnAtGameObject(
                                Inspector.DefendersWallPrefab, PlatformsGround[z][x - 1].transform,
                                PlatformsGround[z][x - 1].transform, "Macrofag"));
                        }
                    }
                }
            }

            //if (_setPositionAtWorldCenter)
            //    SetPositionAtWorldCenter();
            FixPosition();

            //app.controller.BattleField.Notify("ground.instantiate");
        }
    }
}