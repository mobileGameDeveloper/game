using System;
using System.Collections.Generic;

namespace Modules.Level.Scripts.LevelItems
{
    public class LevelItemComponents
    {
        private readonly Dictionary<Type, object> components;

        public LevelItemComponents()
        {
            components = new Dictionary<Type, object>();
        }

        public T GetComponent<T>()
        {
            var componentType = typeof(T);
            if (components.TryGetValue(componentType, out var component))
            {
                return (T) component;
            }
            return default;
        }
        
        public void AddComponent<T>(T component)
        {
            var componentType = typeof(T);
            components[componentType] = component;
        }
    }
}