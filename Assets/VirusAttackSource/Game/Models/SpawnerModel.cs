using Assets.VirusAttackSource.AMVCC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.VirusAttackSource.Game.Models {

    [AddComponentMenu("Virus-Attack Source/SpawnerModel")]
    public sealed class SpawnerModel : Model<VirusAttack> {

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

        internal GameObject SpawnAtPosition(
            GameObject prefab,
            Vector3 position,
            string name = default(string),
            GameObject parent = default(GameObject)) {
            GameObject spawnedGameObject = Instantiate(prefab, position, Quaternion.identity) as GameObject;

            if (parent != null)
                spawnedGameObject.transform.SetParent(parent.transform);

            if (name != default(string))
                spawnedGameObject.name = name;

            return spawnedGameObject;

        }

    }
}
