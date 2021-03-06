﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace AssetStudio
{
    class TextAsset
    {
        public string m_Name;
        public byte[] m_Script;

        public TextAsset(AssetPreloadData preloadData, bool readSwitch)
        {
            var sourceFile = preloadData.sourceFile;
            var reader = preloadData.InitReader();

            if (sourceFile.platform == -2)
            {
                uint m_ObjectHideFlags = reader.ReadUInt32();
                PPtr m_PrefabParentObject = sourceFile.ReadPPtr();
                PPtr m_PrefabInternal = sourceFile.ReadPPtr();
            }

            m_Name = reader.ReadAlignedString();

            if (readSwitch)
            {
                m_Script = reader.ReadBytes(reader.ReadInt32());
            }
            else
            {
                preloadData.extension = ".txt";
                preloadData.Text = m_Name;
            }
        }
    }
}
