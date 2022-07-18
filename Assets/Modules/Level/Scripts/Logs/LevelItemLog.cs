#define LEVEL_ITEM_DEBUG_LOG
using UnityEngine;

namespace Modules.Level.Scripts.Logs
{
    public class LevelItemLog
    {
        public static void Log(object message)
        {
#if LEVEL_ITEM_DEBUG_LOG
            Debug.Log($"[LevelItem] {message}");
#endif
        }
    }
}