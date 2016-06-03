using System.Text;
using UnityEngine;
using VirusAttackSource.AMVCC;

namespace VirusAttackSource.Game.Models.BattleField {

    [AddComponentMenu("Virus-Attack Source/Models/BattleField/BattleFieldModel")]
    public class BattleFieldModel : Model<VirusAttack> {

        private float _sizeX, _sizeY, _sizeZ;
        private GameObject[,] platforms;

        [SerializeField] private GameObject platformPrefab;
        [SerializeField] private int countX;
        [SerializeField] private int countZ;
        [SerializeField] public bool setPositionAtWorldCenter;

        private void SetPositionAtWorldCenter() {

            _sizeX = platformPrefab.transform.localScale.x * countX;
            _sizeY = platformPrefab.transform.localScale.y;
            _sizeZ = platformPrefab.transform.localScale.z * countZ;

            transform.position = new Vector3(_sizeX * -0.5f, _sizeY * -0.5f, _sizeZ * -0.5f);
        }

        private void Generate() {

            platforms = new GameObject[countX, countZ];

            for (int z = 0; z < countZ; z++) {
                for (int x = 0; x < countX; x++) {
                    platforms[x, z] = Instantiate(
                        platformPrefab,
                        new Vector3(
                            platformPrefab.transform.localScale.x * x + platformPrefab.transform.localScale.x * 0.5f,
                            platformPrefab.transform.localScale.y * 0.5f,
                            platformPrefab.transform.localScale.z * z + platformPrefab.transform.localScale.z * 0.5f
                            ),
                        Quaternion.identity) as GameObject;
                    platforms[x, z].transform.SetParent(transform, true);
                    platforms[x, z].name = new StringBuilder("Platform")
                        .Append('_').Append(z).Append('-').Append(x).ToString();

                    app.view.BattleField.OnPlatformInstantiate(platforms[x, z].name); // <-- example model notify view
                }
            }
            if (setPositionAtWorldCenter)
                SetPositionAtWorldCenter();
        }

        private void Start() {
            Generate();
        }
    }
}