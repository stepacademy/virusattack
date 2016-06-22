using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Assets.VirusAttackSource.AMVCC;


namespace Assets.VirusAttackSource.Game.Models.BattleField.Tracks {

    using Utilities;
    using Support;

    [AddComponentMenu("Virus-Attack/BattleField/Tracks/TracksModel")]
    public sealed class TracksModel : Model<VirusAttack> {

        private float newPlatformXZScale;

        internal TracksInspector Inspector { get; private set; }

        internal List<GameObject> Track { get; private set; }

        internal TracksModel SetPreset(TracksInspector tracksInspector) {
            Inspector = tracksInspector;
            return this;
        }

        internal void Generate() {
            PrepareInfrastrucure();
            GenerateTracks();
            RotateTracks();
        }

        private void PrepareInfrastrucure() {
            CalculateNewPlatformXZSize();
            AllocateTracks();
        }

        private void CalculateNewPlatformXZSize() {
            newPlatformXZScale = app.model.BattleField.Base.Inspector.BaseXZSize / Inspector.CellsResolutionWidth;
        }

        private void AllocateTracks() {

            int tracksCount = GetTracksCount();
            Track = new List<GameObject>(tracksCount);

            for (int i = 0; i < tracksCount; ++i) {
                Track.Add(new GameObject());
                Track[i].transform.SetParent(transform);
                Track[i].AddComponent<Track>();
                Track[i].name = "Track " + (char)('A' + i);
            }
        }

        private int GetTracksCount() {
            switch (Inspector.TracksType) {
                default:
                case TracksType.ITypeSmall: return 1;
                case TracksType.ITypeLarge:
                case TracksType.LType: return 2;
                case TracksType.TType: return 3;
                case TracksType.XType: return 4;
            }
        }

        private void GenerateTracks() {
            foreach (GameObject track in Track) {
                GenerateTrack(track.GetComponent<Track>()); // <-- warning, get component, need fix
            }
        }

        private void GenerateTrack(Track currentTrack) {

            int CountX = Inspector.CellsResolutionWidth;
            int CountZ = Inspector.CellsResolutionLength;

            Spawner spawner = new Spawner();

            currentTrack.PlatformsWall = new List<List<GameObject>>(CountZ);
            currentTrack.PlatformsGround = new List<List<GameObject>>(CountZ);

            currentTrack.Macrofags = new List<GameObject>(CountX - 2);

            for (int z = 0; z < CountZ; ++z) {

                currentTrack.PlatformsWall.Add(new List<GameObject>(2));
                currentTrack.PlatformsGround.Add(new List<GameObject>(CountX - 2));

                for (int x = 0; x < CountX; ++x) {

                    if (x == 0 || x == CountX - 1) {
                        currentTrack.PlatformsWall[z].Add(spawner.SpawnAtPosition(
                            Inspector.PlatformWallPrefab,
                            CalculateNextPlatformPosition(x, z, Inspector.PlatformWallPrefab.transform.localScale.y),
                            currentTrack.transform, GenerateCurrentPlatformName("Wall", x, z)));
                    }
                    else {
                        currentTrack.PlatformsGround[z].Add(spawner.SpawnAtPosition(
                            Inspector.PlatformGroundPrefab,
                            CalculateNextPlatformPosition(x, z, Inspector.PlatformGroundPrefab.transform.localScale.y),
                            currentTrack.transform, GenerateCurrentPlatformName("Ground", x, z)));

                        if (z == 0) {
                            currentTrack.Macrofags.Add(spawner.SpawnAtGameObject(
                                Inspector.DefendersWallPrefab, currentTrack.PlatformsGround[z][x - 1].transform,
                                currentTrack.PlatformsGround[z][x - 1].transform, "Macrofag"));
                        }
                    }
                }
            }

            foreach (var row in currentTrack.PlatformsWall) {
                foreach (var platform in row) {
                    platform.transform.localScale =
                        new Vector3(newPlatformXZScale, platform.transform.localScale.y, newPlatformXZScale);
                }
            }

            foreach (var row in currentTrack.PlatformsGround) {
                foreach (var platform in row) {
                    platform.transform.localScale =
                        new Vector3(newPlatformXZScale, platform.transform.localScale.y, newPlatformXZScale);
                }
            }

            foreach (var macrofag in currentTrack.Macrofags) {
                macrofag.transform.localScale =
                        new Vector3(newPlatformXZScale, macrofag.transform.localScale.y, newPlatformXZScale);
            }
        }

        private Vector3 CalculateNextPlatformPosition(int indexX, int indexZ, float savedScaleY) {
            return new Vector3(
                -app.model.BattleField.Base.Inspector.BaseXZSize * 0.5f +
                indexX * newPlatformXZScale + newPlatformXZScale * 0.5f,
                savedScaleY * 0.5f,
                -app.model.BattleField.Base.Inspector.BaseXZSize * 0.5f -
                indexZ * newPlatformXZScale - newPlatformXZScale * 0.5f);
        }

        private string GenerateCurrentPlatformName(string platformPrefabTag, int platformNumberX, int platformNumberZ) {
            return new StringBuilder("Platform")
                        .Append(" | z:").Append(platformNumberZ).Append(" | x:").Append(platformNumberX)
                        .Append(" | tag:").Append(platformPrefabTag).ToString();
        }

        private void RotateTracks() {

            for (int i = 0; i < Track.Count; ++i)
                Track[i].transform.Rotate(0.0f, i * 90.0f, 0.0f);

            if (Inspector.TracksType == TracksType.ITypeLarge)
                Track[1].transform.Rotate(0.0f, 90.0f, 0.0f);

        }
    }
}