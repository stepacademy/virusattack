using System.Text;
using UnityEngine;
using Assets.VirusAttackSource.AMVCC;

namespace Assets.VirusAttackSource.Game.Models.BattleField {

    [AddComponentMenu("Virus-Attack Source/Models/BattleField/BattleFieldModel")]
    public class BattleFieldModel : Model<VirusAttack> {

        private float _sizeX, _sizeY, _sizeZ;

        private GameObject[,] _platforms;
        private GameObject    _macrofag;
        
        public int        CountX = 5;
        public int        CountZ = 12;
        [SerializeField] private bool       _setPositionAtWorldCenter = true;

        [SerializeField] private GameObject _platformPrefab = null;
        [SerializeField] private GameObject _macrofagPrefab = null;

        private void SetPositionAtWorldCenter() {

            _sizeX =  _platformPrefab.transform.localScale.x * CountX;
            _sizeY =  _platformPrefab.transform.localScale.y;
            _sizeZ = -_platformPrefab.transform.localScale.z * CountZ;

            transform.position = new Vector3(_sizeX * -0.5f, _sizeY * -0.5f, _sizeZ * -0.5f);
        }

        internal void Generate() {

            _platforms = new GameObject[CountX, CountZ];

            for (int z = 0; z < CountZ; z++) {
                for (int x = 0; x < CountX; x++) {

                    _platforms[x, z] = Instantiate(
                        _platformPrefab,
                        new Vector3(
                            _platformPrefab.transform.localScale.x *  x + _platformPrefab.transform.localScale.x * 0.5f,
                            _platformPrefab.transform.localScale.y *  0.5f,
                            _platformPrefab.transform.localScale.z * -z - _platformPrefab.transform.localScale.z * 0.5f
                            ),
                        Quaternion.identity) as GameObject;

                    //PlatformModel pm = _platforms[x, z].GetComponent<PlatformModel>();
                    //pm.PosXInGrid = (uint)x;
                    //pm.PosZInGrid = (uint)z;

                    _platforms[x, z].transform.SetParent(transform, true);

                    if (x == 0 || x == CountX - 1)
                        _platforms[x, z].tag = "Wall";
                    else
                        _platforms[x, z].tag = "Ground";

                    _platforms[x, z].name = new StringBuilder("Platform")
                        .Append(" | z:").Append(z).Append(" | x:").Append(x)
                        .Append(" | tag:").Append(_platforms[x, z].tag).ToString();

                    if (z == 0) {
                        _macrofag = Instantiate(_macrofagPrefab,
                            new Vector3(
                                _platforms[x, z].transform.position.x,
                                _platforms[x, z].transform.position.y + 0.5f,
                                _platforms[x, z].transform.position.z),
                            Quaternion.identity) as GameObject;

                        _macrofag.transform.SetParent(_platforms[x, z].transform, true);

                    }                    
                }
            }

            if (_setPositionAtWorldCenter)
                SetPositionAtWorldCenter();

            app.view.BattleField.OnBattleFieldGenerated();
        }
    }
}