using System.Text;
using UnityEngine;
using VirusAttackSource.AMVCC;

namespace VirusAttackSource.Game.Models.BattleField
{

    [AddComponentMenu("Virus-Attack Source/Models/BattleField/BattleFieldModel")]
    public class BattleFieldModel : Model<VirusAttack>
    {

        private float _sizeX, _sizeY, _sizeZ;
        public GameObject[,] platforms;        
        public GameObject macrofagPrefab;
        private GameObject _macrofag;

        [SerializeField]
        private GameObject platformPrefab;
        [SerializeField]
        private int countX;
        [SerializeField]
        private int countZ;
        [SerializeField]
        public bool setPositionAtWorldCenter;

        private void SetPositionAtWorldCenter()
        {

            _sizeX = platformPrefab.transform.localScale.x * countX;
            _sizeY = platformPrefab.transform.localScale.y;
            _sizeZ = -platformPrefab.transform.localScale.z * countZ;

            transform.position = new Vector3(_sizeX * -0.5f, _sizeY * -0.5f, _sizeZ * -0.5f);
        }

        private void Generate()
        {

            platforms = new GameObject[countX, countZ];
            
            for (int z = 0; z < countZ; z++)
            {
                for (int x = 0; x < countX; x++)
                {
                    platforms[x, z] = Instantiate(
                        platformPrefab,
                        new Vector3(
                            platformPrefab.transform.localScale.x * x + platformPrefab.transform.localScale.x * 0.5f,
                            platformPrefab.transform.localScale.y * 0.5f,
                            platformPrefab.transform.localScale.z * -z - platformPrefab.transform.localScale.z * 0.5f
                            ),
                        Quaternion.identity) as GameObject;
                    platforms[x, z].transform.SetParent(transform, true);

                    if (x == countX-1 || x == 0)
                        platforms[x, z].tag = "wall";
                    else
                        platforms[x, z].tag = "ground";

                    platforms[x, z].name = new StringBuilder("Platform")
                        .Append('_').Append(z).Append('-').Append(x).Append(platforms[x, z].tag).ToString();

                    if (z == 0)
                    {
                        _macrofag = Instantiate(macrofagPrefab, 
                            new Vector3(
                                platforms[x, z].transform.position.x, 
                                platforms[x, z].transform.position.y + 0.5f, 
                                platforms[x, z].transform.position.z), 
                            Quaternion.identity) as GameObject;
                        _macrofag.transform.SetParent(platforms[x, z].transform, true);
                    }

                    app.view.BattleField.OnPlatformInstantiate(platforms[x, z].name); // <-- example model notify view
                }
            }
            if (setPositionAtWorldCenter)
                SetPositionAtWorldCenter();
        }

        private void Start()
        {
            Generate();
        }
    }
}