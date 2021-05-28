﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Linq;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;

namespace Jadcup.Common.Helper
{
    public class GeneralMethods
    {
        public static string createGuid()
        {
            return Guid.NewGuid().ToString();
        }

        public static DateTime createTime()
        {
            return DateTime.UtcNow;
        }

        //To hash password and salt
        public static void HashPassword(string password, out string passwordHash, out string passwordSalt)
        {
            byte[] random = new Byte[8];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(random);
            using (var hmac = new System.Security.Cryptography.HMACSHA256(random))
            {
                passwordSalt = Convert.ToBase64String(random);
                var Hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                passwordHash = Convert.ToBase64String(Hash);
            }
        }

        /* This function is to check that the input password is the same with 
         * the hashed password recorded in the database.
         * 
         * password --- input password
         * passwordHash --- hashed password in db
         * passwordSalt --- salt in db
         */
        public static bool VerifyPasswordHash(string password, string passwordHash, string passwordSalt)
        {
            using (var hmac = new HMACSHA256(Convert.FromBase64String(passwordSalt)))
            {
                var computedHash = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(password)));
                if (computedHash != passwordHash)
                {
                    return false;
                }
                return true;
            }
        }
    }
}
