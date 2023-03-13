using System.Collections.Generic;

namespace Json
{
    [System.Serializable]
    public class SaveObject
    {
        public List<LevelData> levelFinish = new List<LevelData>();
        public int fishLevel;
        public int fishCount;
        //public List<bool> customers;
    }
    [System.Serializable]
    public class LevelData
    {
        public bool levelState;
        public bool fishState;
    }
}

