using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.VirusAttackSource.AMVCC;

namespace Assets.VirusAttackSource.Game.Models.Spawner {

    using Utilities;

    [AddComponentMenu("Virus-Attack Source/Spawner/SpawnerModel")]
    public sealed class SpawnerModel : Model<VirusAttack> {

        public List<Wave> Waves { get; set; }

        internal GameObject SpawnAtPosition(GameObject prefab, Vector3 position, Transform parent = null, string name = null) {

            GameObject spawnedGameObject = Instantiate(prefab, position, Quaternion.identity) as GameObject;

            if (parent != null) spawnedGameObject.transform.SetParent(parent);
            if (name   != null) spawnedGameObject.name = name;

            return spawnedGameObject;
        }

        internal GameObject SpawnAtGameObject(GameObject prefab, Transform obj, Transform parent = null, string name = null) {

            float
                x = obj.position.x,
                y = obj.position.y + prefab.transform.localScale.y * 0.5f,
                z = obj.position.z;

            return SpawnAtPosition(prefab, new Vector3(x, y, z), parent == null ? obj.transform : parent, name);
        }

        internal IEnumerator WaveSpawn(List<PrefabCountPair> wave, float waitTime = 1) {

            int countX = app.model.BattleField.CountX;
            int countZ = app.model.BattleField.CountZ;            

            while (wave.Count > 0) {

                int currentPrefabIndex = Random.Range(0, wave.Count);

                int platformIndex  = Random.Range(countX * countZ - countX + 1, countX * countZ - 1);
                Transform platform = app.model.BattleField.transform.GetChild(platformIndex);

                SpawnAtGameObject(wave[currentPrefabIndex].Prefab, platform, transform);
                wave[currentPrefabIndex].Count--;
                wave.RemoveAll(x => x.Prefab == null || x.Count == 0);

                yield return new WaitForSeconds(waitTime);
            }

            Waves.RemoveAll(x => x.LevelEnemiesTypes.Count == 0);

            if (Waves.Count > 0)
                Notify("wave.invokeNext");
        }

        internal IEnumerator SpawnNextWave() {

            Log("\nWait " + Waves[0].DelayBeforeStart + " seconds for start next wave...");
            yield return new WaitForSeconds(Waves[0].DelayBeforeStart);

            Log("\nWave started!");
            Waves.RemoveAll(x => x.LevelEnemiesTypes.Count == 0);
            StartCoroutine(WaveSpawn(Waves[0].LevelEnemiesTypes, Waves[0].SpawnInterval));            
        }
    }
}