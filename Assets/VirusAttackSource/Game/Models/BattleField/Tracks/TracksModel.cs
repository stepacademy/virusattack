using System.Collections.Generic;
using UnityEngine;
using Assets.VirusAttackSource.AMVCC;


namespace Assets.VirusAttackSource.Game.Models.BattleField.Tracks {

    using Support;

    [AddComponentMenu("Virus-Attack/BattleField/Tracks/TracksModel")]
    public sealed class TracksModel : Model<VirusAttack> {

        private  List<GameObject> _track;
        internal GameObject       this[int index] { get { return _track[index]; } }
        internal int              Count           { get { return _track.Count;  } }

        internal TracksInspector  Inspector       { get; private set; }

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

            int tracksCount = GetTracksCount();
            _track = new List<GameObject>(tracksCount);

            for (int i = 0; i < tracksCount; ++i) {
                _track.Add(new GameObject());
                _track[i].transform.SetParent(transform);
                _track[i].AddComponent<TrackModel>();
                _track[i].name = "Track " + (char)('A' + i);
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
            foreach (GameObject track in _track) {
                track.GetComponent<TrackModel>().Generate(Inspector); // <-- warning, get component, need fix
            }
        }

        private void RotateTracks() {

            for (int i = 0; i < _track.Count; ++i)
                _track[i].transform.Rotate(0.0f, i * 90.0f, 0.0f);

            if (Inspector.TracksType == TracksType.ITypeLarge)
                _track[1].transform.Rotate(0.0f, 90.0f, 0.0f);

        }
    }
}