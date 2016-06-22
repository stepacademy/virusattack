using System.Text;
using System.Collections.Generic;
using UnityEngine;
using Assets.VirusAttackSource.AMVCC;


namespace Assets.VirusAttackSource.Game.Models.BattleField.Tracks {

    using Utilities;

    public sealed class TrackModel : Model<VirusAttack> {

        private float _newPlatformXZScale;

        internal List<List<GameObject>> PlatformsWall   { get; private set; }
        internal List<List<GameObject>> PlatformsGround { get; private set; }
        internal List<GameObject>       Macrofags       { get; private set; }

        internal void Generate(TracksInspector inspector) {

            _newPlatformXZScale = app.model.BattleField.Base.Inspector.BaseXZSize / inspector.CellsResolutionWidth;

            int CountX = inspector.CellsResolutionWidth;
            int CountZ = inspector.CellsResolutionLength;

            Spawner spawner = new Spawner();

            PlatformsWall   = new List<List<GameObject>>(CountZ);
            PlatformsGround = new List<List<GameObject>>(CountZ);

            Macrofags = new List<GameObject>(CountX - 2);

            for (int z = 0; z < CountZ; ++z) {

                PlatformsWall.Add(new List<GameObject>(2));
                PlatformsGround.Add(new List<GameObject>(CountX - 2));

                for (int x = 0; x < CountX; ++x) {

                    if (x == 0 || x == CountX - 1) {
                        PlatformsWall[z].Add(spawner.SpawnAtPosition(
                            inspector.PlatformWallPrefab,
                            CalculateNextPlatformPosition(x, z, inspector.PlatformWallPrefab.transform.localScale.y),
                            transform, GenerateCurrentPlatformName("Wall", x, z)));
                    }
                    else {
                        PlatformsGround[z].Add(spawner.SpawnAtPosition(
                            inspector.PlatformGroundPrefab,
                            CalculateNextPlatformPosition(x, z, inspector.PlatformGroundPrefab.transform.localScale.y),
                            transform, GenerateCurrentPlatformName("Ground", x, z)));

                        if (z == 0) {
                            Macrofags.Add(spawner.SpawnAtGameObject(
                                inspector.DefendersWallPrefab, PlatformsGround[z][x - 1].transform,
                                PlatformsGround[z][x - 1].transform, "Macrofag"));
                        }
                    }
                }
            }

            foreach (var row in PlatformsWall) {
                foreach (var platform in row) {
                    platform.transform.localScale =
                        new Vector3(_newPlatformXZScale, platform.transform.localScale.y, _newPlatformXZScale);
                }
            }

            foreach (var row in PlatformsGround) {
                foreach (var platform in row) {
                    platform.transform.localScale =
                        new Vector3(_newPlatformXZScale, platform.transform.localScale.y, _newPlatformXZScale);
                }
            }

            foreach (var macrofag in Macrofags) {
                macrofag.transform.localScale =
                    new Vector3(0.9f, macrofag.transform.localScale.y, 0.9f);
            }
        }

        private Vector3 CalculateNextPlatformPosition(int indexX, int indexZ, float savedScaleY) {
            return new Vector3(
                -app.model.BattleField.Base.Inspector.BaseXZSize * 0.5f +
                indexX * _newPlatformXZScale + _newPlatformXZScale * 0.5f,
                savedScaleY * 0.5f,
                -app.model.BattleField.Base.Inspector.BaseXZSize * 0.5f -
                indexZ * _newPlatformXZScale - _newPlatformXZScale * 0.5f);
        }

        private string GenerateCurrentPlatformName(string platformPrefabTag, int platformNumberX, int platformNumberZ) {
            return new StringBuilder("Platform")
                        .Append(" | z:").Append(platformNumberZ).Append(" | x:").Append(platformNumberX)
                        .Append(" | tag:").Append(platformPrefabTag).ToString();
        }
    }
}