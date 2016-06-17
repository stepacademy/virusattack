using System;
using System.Collections.Generic;

namespace Assets.VirusAttackSource.Utilities {

    [Serializable]
    public sealed class Player {

        public int    IserId   = 0;
        public string UserName = "User";
        public int    DnaCount = 1000;
        public int    RnaCount = 100;
        public List<bool> AvailableLevels;


        private List<string> LoadAllProfiles() {
            throw new NotImplementedException();
        }

        private void LoadProfile(string userName) {
            throw new NotImplementedException();
        }

        private void SaveProfile() {
            throw new NotImplementedException();
        }
    }
}