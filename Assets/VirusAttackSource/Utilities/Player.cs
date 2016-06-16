using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.VirusAttackSource.Utilities {

    using Utilities;

    [Serializable]
    public sealed class Player {

        public int    IserId;
        public string UserName;
        public int    DnaCount;
        public int    RnaCount;
        public List<bool> AvailableLevels;

    }
}