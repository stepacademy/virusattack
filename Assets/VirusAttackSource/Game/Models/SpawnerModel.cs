using System.Collections;
using UnityEngine;
using Assets.VirusAttackSource.AMVCC;

namespace Assets.VirusAttackSource.Game.Models {

    using Utilities;

    [AddComponentMenu("Virus-Attack Source/SpawnerModel")]
    public sealed class SpawnerModel : Model<VirusAttack> {

        internal GameObject SpawnAtPosition(GameObject prefab, Vector3 position, string name = null, GameObject parent = null) {

            GameObject spawnedGameObject = Instantiate(prefab, position, Quaternion.identity) as GameObject;

            if (parent != null)
                spawnedGameObject.transform.SetParent(parent.transform);

            if (name != null)
                spawnedGameObject.name = name;

            return spawnedGameObject;

        }

        internal GameObject SpawnAtGameObject(GameObject prefab, Transform obj, Transform parent = null, string name = null) {

            if (obj == null) {
                Log("Error: missing parent. Execution is interrupted.");
                return null;
            }
            if (prefab == null) {
                prefab = GameObject.CreatePrimitive(PrimitiveType.Cube);
                Log("Warning: missing the Prefab of instantiated object. Will be used a default primitive: Cube.");
            }

            GameObject spawnedGameObject = Instantiate(
                        prefab,
                        new Vector3(
                            obj.position.x,
                            obj.position.y + prefab.transform.localScale.y / 2,
                            obj.position.z
                            ),
                        Quaternion.identity) as GameObject;

            if (parent == null)
                spawnedGameObject.transform.SetParent(obj.transform);
            else
                spawnedGameObject.transform.SetParent(parent.transform);

            if (name != null)
                spawnedGameObject.name = name;

            return spawnedGameObject;
        }

        private IEnumerator SpawnClones(PrefabCountPair clones, float waitTime) {            

            int countX = app.model.BattleField.CountX;
            int countZ = app.model.BattleField.CountZ;

            while (clones.Count > 0) {

                yield return new WaitForSeconds(waitTime * clones.Count--);

                int platformIndex  = Random.Range(countX * countZ - countX + 1, countX * countZ - 1);
                Transform platform = app.model.BattleField.transform.GetChild(platformIndex);

                SpawnAtGameObject(clones.Prefab, platform, transform);
            }
        }

        internal IEnumerator SpawnEnemiesWave(Wave wave) {

            int totalEnemiesInWave = 0;
            foreach (var item in wave.LevelEnemiesTypes)
                totalEnemiesInWave += item.Count;

            while (wave.LevelEnemiesTypes.Count > 0) {                
                StartCoroutine_Auto(SpawnClones(wave.LevelEnemiesTypes[0], wave.SpawnInterval));
                wave.LevelEnemiesTypes.RemoveAll(x => x.Prefab == null || x.Count == 0);
            }

            yield return new WaitForSeconds(totalEnemiesInWave * wave.SpawnInterval + wave.WaitForNextWave);
            Notify("wave.spawned");
        }
    }
}