﻿using GeometryDashAPI.Levels.Enums;
using GeometryDashAPI.Levels.GameObjects.Default;

namespace GeometryDashAPI.Levels.GameObjects.Specific
{
    public enum JumpSphereID
    {
        Yellow = 36,
        Purple = 141,
        Red = 1333,
        LightBlue = 84,
        Green = 1022,
        Dark = 1330,
        ArrowGreen = 1704,
        ArrowPurple = 1751
    }

    public class JumpSphere : Block
    {
        public override Layer Default_ZLayer { get; protected set; } = Layer.B1;
        public override short Default_ZOrder { get; protected set; } = 12;

        public bool MultiActivate { get; set; }

        public JumpSphereID BlockType
        {
            get => (JumpSphereID)ID;
            set => ID = (int)value;
        }

        public JumpSphere(JumpSphereID type) : base((int)type)
        {
        }

        public JumpSphere(string[] data)
        {
            for (int i = 0; i < data.Length; i += 2)
                LoadProperty(byte.Parse(data[i]), data[i + 1]);
        }

        public override void LoadProperty(byte key, string value)
        {
            switch (key)
            {
                case 99:
                    MultiActivate = GameConvert.StringToBool(value);
                    return;
                default:
                    base.LoadProperty(key, value);
                    return;
            }
        }

        public override string ToString()
        {
            if (MultiActivate)
                return $"{base.ToString()},99,1";
            else
                return base.ToString();
        }
    }
}
