using CaeserCipherEncoder.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaeserCipherEncoder
{
    public class CaeserCipherEncoder
    {

        private static void Main(string[] args)
        {

        }

        ///<summary>
        ///Užšifravimo metodas <c>Encode</c>
        ///</summary>
        ///<paramref name="offset"/> - raktas(<c>int</c>) per, kurį raidės bus pastumiamos į vieną ar kitą pusę
        ///<paramref name="value"/> - tekstas(<c>string</c>), kurį norima užšifruoti
        public static string Encode(string value, int offset)
        {
            return CharacterManipulationHelper.CipherString(value, offset, true);   
        }

        ///<summary>
        ///Iššifravimo metodas <c>Decode</c>
        ///</summary>
        ///<paramref name="offset"/> - raktas(<c>int</c>) per, kurį raidės bus pastumiamos į vieną ar kitą pusę
        ///<paramref name="value"/> - tekstas(<c>string</c>), kurį norima iššifruoti
        public static string Decode(string value, int offset)
        {
            return CharacterManipulationHelper.CipherString(value, offset, false);
        }



    }
}
