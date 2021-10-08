using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaeserCipherEncoder.Helpers
{
    public class CharacterManipulationHelper
    {
        //Abėcėlė, naudojama užšifravimui. Naudojama kobinuota lietuviškų ir lotyniškų raidžių abėcėlė. 
        private static string Alphabet = "AĄBCČDEĘĖFGHIĮJKLMNOPQRSŠTUŲŪVWXYZŽaąbcčdeęėfghiįjklmnopqrsštuųūvwxyzž";

        /// <summary>
        /// <c>CipherString</c> Šifravimo metodas, 
        /// paduodami parametrai val(<c>string</c>), offset(<c>int</c>) ir encode(<c>boolean</c>).
        /// Grąžina <c>string</c>.
        /// </summary>
        /// <param name="val">Šifruojamas tekstas</param>
        /// <param name="offset">Šifravimo raktas, paslinkimas</param>
        /// <param name="encode">Užšifravimas/Iššifravimas</param>
        /// <returns>String</returns>
        public static string CipherString(string val, int offset, bool encode)
        {
            //naudojamas mod, kad paslinkimas neišeitų už rėžio ribų - IndexOutOfRangeException.
            offset = offset % Alphabet.Length; 
            //kai paslinkimas mažesnis už nulį iš rėžio ilgio atimamas paslinkimas, nes kitaip gali būti gautas IndexOutOfRangeException
            if (offset < 0)
                offset = Alphabet.Length + offset;
            //Kai vyksta iššifravimas paslinkimas į kitą pusę.
            if (!encode)
                offset = Alphabet.Length - offset;

            return CipherString(val, offset);
        }
        private static string CipherString(string val, int offset)
        {
            string result = string.Empty;
            //Gautą reikšmė "val" verčiama į char masyvą. Einama per kiekvieną ženklą masyve ir šifruojama pagal poslinkį "offset" pridedama prie rezultato.
            foreach (char ch in val.ToCharArray())
            {               
                result += Alphabet.IndexOf(ch) < 0 ?
                            //Jeigu tokio simbolio nėra "abėcėlėje" grąžinamas toks pat simbolis
                            ch 
                            :
                            /*
                              
                              Alphabet.ElementAt() - pagal index'ą parenkamas simbolis iš abėcėlės
                              Alphabet.IndexOf(ch) + offset - gaunamas simbolio indexas string'e Alphabet ir pridedamas poslinkis offset
                              Alphabet.Length / 2 - pusė raidžių abėcėlėje didžiosios kitos mažiosios. Naudojama pusė ilgio, kad didžiosios liktų didžiosios, o mažiosios - mažosios
                              % - mod naudojamas, kad nebūtų į masyvą nepatenkančių indexų
                              char.IsUpper(ch) - Jeigu didžioji raidė, tai naudojamas didžiųjų raidžių pradžios indexas(A raidė), jeigu mažoji raidė, tai naudojmas mažųjų raidžių pradžios indexas(a raidė)

                            */
                            Alphabet.ElementAt(((Alphabet.IndexOf(ch) + offset) % (Alphabet.Length / 2)) + (char.IsUpper(ch) ? Alphabet.IndexOf('A') : Alphabet.IndexOf('a')));
                            
            }

            return result; 
        }

    }
}
