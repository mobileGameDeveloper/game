namespace Core
{
    using System;
    using System.Collections.Generic;

    namespace Core
    {
        public static class ServiceLocator
        {
            private static readonly Dictionary<Type, object> Services = new Dictionary<Type, object>();

            public static bool Add<T>(T obj)
            {
                if (Services.ContainsKey(typeof(T)))
                {
                    return false;
                }
			
                Services.Add(typeof(T), obj);
                return true;
            }

            public static T Get<T>() where T : class
            {
                if (Services.ContainsKey(typeof(T)))
                {
                    return (T) Services[typeof(T)];
                }
			
                return null;
            }
            
            public static void Clear()
            {
                Services?.Clear();
            }
        }
    }
}