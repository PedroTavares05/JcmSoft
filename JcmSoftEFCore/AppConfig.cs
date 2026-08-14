using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JcmSoftEFCore.Context;

public static class AppConfig
{
    public static string GetConnectionString()
    {
        // 1. String na mesma linha. Note a troca de "sa" para "root" (Uid e Pwd são as siglas padrão do MySQL).
        return "Server=localhost;Database=JcmSoftDb;Uid=root;Pwd=12345;";
    }
}
