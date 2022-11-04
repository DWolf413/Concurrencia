﻿using System.Security.Cryptography;

namespace WebApi.Helpers
{
    public class RandomGen
    {
        private static RNGCryptoServiceProvider _global = new RNGCryptoServiceProvider(); //Revisar por cual metodo cambiar

        [ThreadStatic]
        private static Random _local;

        public static double NextDouble() 
        {
            Random inst = _local;
            if (inst == null)
            {
                byte[] buffer = new byte[4];
                _global.GetBytes(buffer);
                _local = inst = new Random(BitConverter.ToInt32(buffer, 0));
            }

            return inst.NextDouble();
        }
    }
}
