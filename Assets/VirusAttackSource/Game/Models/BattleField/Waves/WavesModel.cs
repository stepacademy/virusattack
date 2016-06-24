using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.VirusAttackSource.AMVCC;

namespace Assets.VirusAttackSource.Game.Models.BattleField.Waves {

    using Utilities;
    using Support;

    [AddComponentMenu("Virus-Attack/BattleField/Waves/WavesModel")]
    public sealed class WavesModel : Model<VirusAttack> {

        internal WavesInspector Inspector { get; private set; }

        internal WavesModel SetPreset(WavesInspector wavesInspector) {
            Inspector = wavesInspector;
            return this;
        }

        internal void Generate() {

            RemoveAllEmpty();

            if (Inspector.Waves.Count > 0)
                StartCoroutine(SpawnNextWave());
        }

        private void RemoveAllEmpty() {
            foreach (var wave in Inspector.Waves)
                wave.LevelEnemiesTypes.RemoveAll(x => x.Prefab == null || x.Count == 0);
            Inspector.Waves.RemoveAll(x => x.LevelEnemiesTypes.Count == 0);
        }        

        internal IEnumerator SpawnNextWave() {

            Log("Wait " + Inspector.Waves[0].DelayBeforeStart + " seconds for start next wave...\n");
            yield return new WaitForSeconds(Inspector.Waves[0].DelayBeforeStart);

            Log("Wave started!\n");
            Inspector.Waves.RemoveAll(x => x.LevelEnemiesTypes.Count == 0);
            StartCoroutine(WaveSpawn(Inspector.Waves[0].LevelEnemiesTypes, Inspector.Waves[0].SpawnInterval));

        }

        internal IEnumerator WaveSpawn(List<PrefabCountPair> wave, float waitTime) {

            int countX = app.model.BattleField.Tracks.Inspector.CellsResolutionWidth;
            int countZ = app.model.BattleField.Tracks.Inspector.CellsResolutionLength;

            Spawner spawner = new Spawner();

            while (wave.Count > 0) {

                int currentPrefabIndex = Random.Range(0, wave.Count);
                int platformIndex      = Random.Range(countX * countZ - countX + 1, countX * countZ - 1);
                int trackIndex         = Random.Range(0, app.model.BattleField.Tracks.Count);

                Transform platform = app.model.BattleField.Tracks[trackIndex].transform.GetChild(platformIndex);

                GameObject currentEnemy = spawner.SpawnAtGameObject(
                    wave[currentPrefabIndex].Prefab, platform, transform, wave[currentPrefabIndex].Prefab.name);

                currentEnemy.transform.Rotate(app.model.BattleField.Tracks[trackIndex].transform.localEulerAngles);
                currentEnemy.transform.localScale = FixEnemyScale(currentEnemy.transform.localScale, platform.localScale);

                wave[currentPrefabIndex].Count--;
                wave.RemoveAll(x => x.Prefab == null || x.Count == 0);

                yield return new WaitForSeconds(waitTime);
            }

            Inspector.Waves.RemoveAll(x => x.LevelEnemiesTypes.Count == 0);

            if (Inspector.Waves.Count > 0)
                Notify("waves.invokeNext");
        }

        private Vector3 FixEnemyScale(Vector3 oldEnemyScale, Vector3 platformScale) {
            return new Vector3(
                oldEnemyScale.x * platformScale.x,
                oldEnemyScale.y * platformScale.x,
                oldEnemyScale.z * platformScale.x);
        }
    }
}