using System.Text;
using UnityEngine;
using Assets.VirusAttackSource.AMVCC;


namespace Assets.VirusAttackSource.Game.Models.BattleField {

    [AddComponentMenu("Virus-Attack Source/BattleField/BattleFieldModel")]
    public class BattleFieldModel : Model<VirusAttack> {

        private float _sizeX, _sizeZ;

        private GameObject[,] _platformsGround;
        private GameObject[,] _platformsWall;
        private GameObject[]  _macrofags;
        
        public int       CountX = 5;
        public int       CountZ = 12;
        [SerializeField] private bool       _setPositionAtWorldCenter = true;

        [SerializeField] private GameObject _platformGroundPrefab = null;
        [SerializeField] private GameObject _platformWallPrefab   = null;
        [SerializeField] private GameObject _defendersWallPrefab  = null;

        private void SetPositionAtWorldCenter() {

            _sizeX = _platformGroundPrefab.transform.localScale.x * CountX;
            _sizeZ = _platformGroundPrefab.transform.localScale.z * CountZ;

            transform.position = new Vector3(_sizeX * -0.5f, 0, _sizeZ * 0.5f);
        }

        private Vector3 GetNewPlatformPosition(GameObject platformPrefab, int platformNumberX, int platformNumberZ) {

            return new Vector3(
                platformPrefab.transform.localScale.x *  platformNumberX + platformPrefab.transform.localScale.x * 0.5f,
                platformPrefab.transform.localScale.y *  0.5f,
                platformPrefab.transform.localScale.z * -platformNumberZ - platformPrefab.transform.localScale.z * 0.5f
                );
        }

        private GameObject GetCurrentPrefab(string platformPrefabTag) {
            return platformPrefabTag == "Ground" ? _platformGroundPrefab : _platformWallPrefab;
        }

        internal void Generate() {            

            _platformsGround = new GameObject[CountX - 2, CountZ];
            _platformsWall = new GameObject[2, CountZ];
            _macrofags = new GameObject[CountX];

            for (int z = 0; z < CountZ; z++) {
                for (int x = 0; x < CountX; x++) {

                    GameObject currentPlatform;
                    GameObject   currentPrefab;
                    string          currentTag;

                    if (x == 0 || x == CountX - 1) {
                        currentPrefab = GetCurrentPrefab(currentTag = "Wall");
                        currentPlatform = _platformsWall[x == 0 ? 0 : 1, z] =
                            app.model.Spawner.SpawnAtPosition(
                                currentPrefab, GetNewPlatformPosition(currentPrefab, x, z), null, currentTag);
                    }
                    else {
                        currentPrefab = GetCurrentPrefab(currentTag = "Ground");
                        currentPlatform = _platformsGround[x - 1, z] =
                            app.model.Spawner.SpawnAtPosition(
                                currentPrefab, GetNewPlatformPosition(currentPrefab, x, z), null, currentTag);
                    }

                    currentPlatform.transform.SetParent(transform, true);
                    currentPlatform.tag  = currentTag;
                    currentPlatform.name = new StringBuilder("Platform")
                        .Append(" | z:").Append(z).Append(" | x:").Append(x)
                        .Append(" | tag:").Append(currentPlatform.tag).ToString();

                    if (z == 0 && x != 0 && x != CountX - 1) {
                        _macrofags[x] = Instantiate(_defendersWallPrefab,
                            new Vector3(
                                currentPlatform.transform.position.x,
                                currentPlatform.transform.localScale.y + _defendersWallPrefab.transform.localScale.y,
                                currentPlatform.transform.position.z),
                            Quaternion.identity) as GameObject;

                        _macrofags[x].transform.SetParent(currentPlatform.transform, true);

                    }
                }
            }

            if (_setPositionAtWorldCenter)
                SetPositionAtWorldCenter();

            app.view.BattleField.OnBattleFieldGenerated();
        }
    }
}