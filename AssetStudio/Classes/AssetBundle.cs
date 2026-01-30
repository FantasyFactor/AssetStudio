using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssetStudio
{
    public class AssetInfo
    {
        public int preloadIndex;
        public int preloadSize;
        public PPtr<Object> asset;

        public AssetInfo(ObjectReader reader)
        {
            preloadIndex = reader.ReadInt32();
            preloadSize = reader.ReadInt32();
            asset = new PPtr<Object>(reader);
        }
    }

    public sealed class AssetBundle : NamedObject
    {
        public PPtr<Object>[] m_PreloadTable;
        public KeyValuePair<string, AssetInfo>[] m_Container;

        public AssetBundle(ObjectReader reader) : base(reader)
        {
            var m_PreloadTableSize = reader.ReadInt32();
            Logger.Info(string.Format("m_PreloadTableSize:{0}", m_PreloadTableSize));
            m_PreloadTable = new PPtr<Object>[m_PreloadTableSize];
            for (int i = 0; i < m_PreloadTableSize; i++)
            {
                m_PreloadTable[i] = new PPtr<Object>(reader);

                Logger.Info(string.Format("preloadTable index:{0} fileID:{1} pathID:{2}", i, m_PreloadTable[i].m_FileID, m_PreloadTable[i].m_PathID));

                /*if (m_PreloadTable[i].m_PathID == 9188401894465106095)
                {
                    if(m_PreloadTable[i].TryGet<Object>(out Object file))
                    {
                        Logger.Info("file");
                    }
                }*/
            }

            var m_ContainerSize = reader.ReadInt32();
            m_Container = new KeyValuePair<string, AssetInfo>[m_ContainerSize];
            Logger.Info(string.Format("m_PreloadTableSize:{0}", m_PreloadTableSize));
            for (int i = 0; i < m_ContainerSize; i++)
            {
                string key = reader.ReadAlignedString();

                m_Container[i] = new KeyValuePair<string, AssetInfo>(key, new AssetInfo(reader));

                var value = m_Container[i].Value;
                Logger.Info(string.Format("container index:{0} key:{1} preloadIndex:{2} preloadSize:{3} fileID:{4} pathID:{5}", i, key, value.preloadIndex, value.preloadSize, value.asset.m_FileID, value.asset.m_PathID));
            }
        }
    }
}
