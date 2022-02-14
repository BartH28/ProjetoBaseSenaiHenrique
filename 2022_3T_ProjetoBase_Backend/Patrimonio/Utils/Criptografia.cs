using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patrimonio.Utils
{
    public static class Criptografia
    {
        public static string GerarHash(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }

        public static bool ValidarHash(string senhaForm, string senhaBD)
        {
            return BCrypt.Net.BCrypt.Verify(senhaForm, senhaBD);
        }
    }
}
