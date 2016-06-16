using System.Text;
using System.Collections.Generic;
using UnityEngine;
using Assets.VirusAttackSource.AMVCC;

namespace Assets.VirusAttackSource.Game.Models.BattleField {
    
    [AddComponentMenu("Virus-Attack Source/BattleField/BattleFieldModel")]
    public sealed class BattleFieldModel : Model<VirusAttack> {

        private float _sizeX, _sizeZ;

        private List<List<GameObject>> _platformsWall;
        private List<List<GameObject>> _platformsGround;        
        private List<GameObject>       _macrofags;

        public int       CountX = 6;
        public int       CountZ = 14;
        [SerializeField] private bool       _setPositionAtWorldCenter = true;

        [SerializeField] private GameObject _platformGroundPrefab = null;
        [SerializeField] private GameObject _platformWallPrefab   = null;
        [SerializeField] private GameObject _defendersWallPrefab  = null;        

        private Vector3 CalculatePlatformPosition(GameObject platformPrefab, int platformNumberX, int platformNumberZ) {
            return new Vector3(
                platformPrefab.transform.localScale.x *  platformNumberX + platformPrefab.transform.localScale.x * 0.5f,
                platformPrefab.transform.localScale.y *  0.5f,
                platformPrefab.transform.localScale.z * -platformNumberZ - platformPrefab.transform.localScale.z * 0.5f
                );
        }

        private string GenerateCurrentPlatformName(string platformPrefabTag, int platformNumberX, int platformNumberZ) {
            return new StringBuilder("Platform")
                        .Append(" | z:").Append(platformNumberZ).Append(" | x:").Append(platformNumberX)
                        .Append(" | tag:").Append(platformPrefabTag).ToString();
        }

        private void SetPositionAtWorldCenter() {

            _sizeX = _platformGroundPrefab.transform.localScale.x * CountX;
            _sizeZ = _platformGroundPrefab.transform.localScale.z * CountZ;

            transform.position = new Vector3(_sizeX * -0.5f, 0, _sizeZ * 0.5f);
        }

        internal void Generate() {

            _platformsWall   = new List<List<GameObject>>(CountZ);
            _platformsGround = new List<List<GameObject>>(CountZ);
                        
            _macrofags = new List<GameObject>(CountX - 2);

            for (int z = 0; z < CountZ; ++z) {

                _platformsWall.Add(new List<GameObject>(2));
                _platformsGround.Add(new List<GameObject>(CountX - 2));

                for (int x = 0; x < CountX; ++x) {                

                    if (x == 0 || x == CountX - 1) {
                        _platformsWall[z].Add(app.model.Spawner.SpawnAtPosition(
                            _platformWallPrefab, CalculatePlatformPosition(_platformWallPrefab, x, z),
                            transform, GenerateCurrentPlatformName("Wall", x, z)));
                    }
                    else {
                        _platformsGround[z].Add(app.model.Spawner.SpawnAtPosition(
                            _platformGroundPrefab, CalculatePlatformPosition(_platformGroundPrefab, x, z),
                            transform, GenerateCurrentPlatformName("Ground", x, z)));

                        if (z == 0) {
                            _macrofags.Add(app.model.Spawner.SpawnAtGameObject(
                                _defendersWallPrefab, _platformsGround[z][x - 1].transform,
                                _platformsGround[z][x - 1].transform, "Macrofag"));
                        }
                    }
                }
            }

            if (_setPositionAtWorldCenter)
                SetPositionAtWorldCenter();

            app.view.BattleField.OnBattleFieldGenerated();
        }
    }
}