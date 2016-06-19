using UnityEngine;


namespace Assets.VirusAttackSource.Utilities {

    public sealed class Spawner {

        public GameObject SpawnAtPosition(GameObject prefab, Vector3 position, Transform parent = null, string name = null) {

            GameObject spawnedGameObject = Object.Instantiate(prefab, position, Quaternion.identity) as GameObject;

            if (parent != null) spawnedGameObject.transform.SetParent(parent);
            if (name   != null) spawnedGameObject.name = name;

            return spawnedGameObject;
        }

        internal GameObject SpawnAtGameObject(GameObject prefab, Transform obj, Transform parent = null, string name = null) {

            float
                x = obj.position.x,
                y = obj.position.y + obj.transform.localScale.y * 0.5f + prefab.transform.localScale.y * 0.5f,
                z = obj.position.z;

            return SpawnAtPosition(prefab, new Vector3(x, y, z), parent == null ? obj.transform : parent, name);
        }        
    }
}