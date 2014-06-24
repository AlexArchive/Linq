using System;

namespace EmuLinq
{
    public static class Ensure
    {
        public static void IsNotNull(object parameter, string parameterName)
        {
            if (parameter == null) {
                throw new ArgumentNullException(parameterName);
            }
        }
    }
}