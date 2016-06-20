using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.VirusAttackSource.AMVCC;

namespace Assets.VirusAttackSource.Game.Models.BattleField.Waves {

    using Utilities;
    using Support;

    [AddComponentMenu("Virus-Attack/BattleField/Waves/WavesModel")]
    public sealed class WavesModel : Model<VirusAttack> {

        private int _lastEnemyIndex = 0;

        internal WavesInspector Inspector { get; private set; }

        internal WavesModel SetPreset(WavesInspector wavesInspector) {
            Inspector = wavesInspector;
            return this;
        }

        private void RemoveAllEmpty() {
            foreach (var wave in Inspector.Waves)
                wave.LevelEnemiesTypes.RemoveAll(x => x.Prefab == null || x.Count == 0);
            Inspector.Waves.RemoveAll(x => x.LevelEnemiesTypes.Count == 0);
        }

        internal void Generate() {

            RemoveAllEmpty();

            if (Inspector.Waves.Count > 0)
                StartCoroutine(SpawnNextWave());
        }

        internal IEnumerator WaveSpawn(List<PrefabCountPair> wave, float waitTime) {

            int countX = app.model.BattleField.Tracks.Inspector.CellsResolutionWidth;
            int countZ = app.model.BattleField.Tracks.Inspector.CellsResolutionLength;

            Spawner spawner = new Spawner();

            while (wave.Count > 0) {

                int currentPrefabIndex = Random.Range(0, wave.Count);

                int platformIndex  = Random.Range(countX * countZ - countX + 1, countX * countZ - 1);
                Transform platform = app.model.BattleField.Tracks.transform.GetChild(platformIndex);

                spawner.SpawnAtGameObject(
                    wave[currentPrefabIndex].Prefab, platform, transform, wave[currentPrefabIndex].Prefab.name);
                wave[currentPrefabIndex].Count--;
                wave.RemoveAll(x => x.Prefab == null || x.Count == 0);

                yield return new WaitForSeconds(waitTime);
            }

            Inspector.Waves.RemoveAll(x => x.LevelEnemiesTypes.Count == 0);

            if (Inspector.Waves.Count > 0)
                app.controller.BattleField.Waves.Notify("wave.invokeNext");
        }

        internal IEnumerator SpawnNextWave() {

            Log("Wait " + Inspector.Waves[0].DelayBeforeStart + " seconds for start next wave...\n");
            yield return new WaitForSeconds(Inspector.Waves[0].DelayBeforeStart);

            Log("Wave started!\n");
            Inspector.Waves.RemoveAll(x => x.LevelEnemiesTypes.Count == 0);
            StartCoroutine(WaveSpawn(Inspector.Waves[0].LevelEnemiesTypes, Inspector.Waves[0].SpawnInterval));

        }
    }
}