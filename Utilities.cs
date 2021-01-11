using System;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TicketManagerWpf
{
    class Utilities
    {
        internal static async Task<TicketInfo[]> ParseTicketsFromFileAsync(string path)
        {
            StreamReader streamReader;
            try
            {
                streamReader = new StreamReader(path);
                string json = await streamReader.ReadToEndAsync();
                return JsonConvert.DeserializeObject<TicketInfo[]>(json);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}