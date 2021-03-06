﻿using GeometryDashAPI.Data.Enums;
using GeometryDashAPI.Data.Models;
using System.Collections.Generic;

namespace GeometryDashAPI.Data
{
    public class LocalLevels : GameData
    {
        public List<LevelCreatorModel> Levels { get; set; }

        public int BinaryVersion
        {
            get => DataPlist["LLM_02"];
            set => DataPlist["LLM_02"] = value;
        }

        public LocalLevels() : base(GameDataType.LocalLevels)
        {
            this.LoadList();
        }

        public LocalLevels(string fullName) : base(fullName)
        {
            this.LoadList();
        }

        public override void Load()
        {
            base.Load();
            this.LoadList();
        }

        private void LoadList()
        {
            if (this.Levels == null)
                this.Levels = new List<LevelCreatorModel>();
            else
                this.Levels.Clear();

            foreach (var a in DataPlist["LLM_01"])
            {
                if (a.Key == "_isArr")
                    continue;
                Levels.Add(new LevelCreatorModel(a.Key, a.Value));
            }
        }

        public LevelCreatorModel GetLevelByName(string levelName)
        {
            return this.Levels.Find(x => x.Name == levelName);
        }

        public List<LevelCreatorModel> GetAllLevelsByName(string levelName)
        {
            return this.Levels.FindAll(x => x.Name == levelName);
        }

        public bool LevelExist(string levelName)
        {
            return this.Levels.Exists(x => x.Name == levelName);
        }

        public void Remove(LevelCreatorModel level)
        {
            this.Levels.Remove(level);
            DataPlist["LLM_01"].Remove(level.KeyInDict);
        }
    }
}
