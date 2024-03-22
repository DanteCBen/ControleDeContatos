using System.Security.Cryptography;
using System.Text;

namespace ControleDeContatos.Helper;
public static class Criptografia
{
    public static string GerarHash(this string value)
    {
        var hash = SHA1.Create();
        var enconding = new ASCIIEncoding();
        var array = enconding.GetBytes(value);

        array = hash.ComputeHash(array);

        var strHexa = new StringBuilder();

        array.ToList().ForEach(_byte => strHexa.Append(_byte.ToString("x2")));

        return strHexa.ToString();
    }
}