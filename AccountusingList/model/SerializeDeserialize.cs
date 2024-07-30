using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace AccountusingList.model
{
    internal class SerializeDeserialize
    {
        private static string fileName = "AccountData.json";

        // Serialize the list of accounts to a JSON file
        public static void SerializeData(List<Account> accounts)
        {
            File.WriteAllText(fileName, JsonConvert.SerializeObject(accounts));
        }
        public static List<Account> DeserializeData()
        {
            if (!File.Exists(fileName))
            {
                return new List<Account>(); // Return an empty list if the file does not exist
            }
            string json = File.ReadAllText(fileName);
            List<Account> accounts = JsonConvert.DeserializeObject<List<Account>>(json);

            if (accounts == null)
            {
                return new List<Account>(); // Return an empty list if deserialization fails
            }
            return accounts;
        }
    }
}
