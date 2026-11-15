using Lesson24.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace Lesson24.Extentions
{
    internal static class JSONFileHelper<T>
    {
        private static readonly string[] _paths = new string[]
        {
            @"C:\Users\Mate_Okroshiashvili\Desktop\Hotels\Hotels.json",
            @"C:\Users\Mate_Okroshiashvili\Desktop\Hotels\Rooms.json",
            @"C:\Users\Mate_Okroshiashvili\Desktop\Hotels\Users.json",
        };

        private static JsonSerializerOptions _options { get; set; } =
            new JsonSerializerOptions()
            {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
            };

        public async static Task WriteInJsonAsync(FILE_TYPES fileTypes, T entity)
        {
            string serialized = JsonSerializer.Serialize(entity, _options);
            await File.WriteAllTextAsync(_paths[Convert.ToInt32(fileTypes)], serialized);
        }

        public async static Task WriteInJsonAsync(FILE_TYPES fileTypes, List<T> values)
        {
            string serialized = JsonSerializer.Serialize(values, _options);
            await File.WriteAllTextAsync(_paths[Convert.ToInt32(fileTypes)], serialized);
        }

        public async static Task<T?> ReadFromJsonAsync(FILE_TYPES fileTypes) 
        {
            string data = await File.ReadAllTextAsync(_paths[Convert.ToInt32(fileTypes)]);
            T? values = JsonSerializer.Deserialize<T>(data, _options);
            return values;
        }

        //public async static Task<List<T>?> ReadFromJsonAsync(FILE_TYPES fileTypes) 
        //{
        //    string data = await File.ReadAllTextAsync(_paths[Convert.ToInt32(fileTypes)]);
        //    List<T>? values = JsonSerializer.Deserialize<List<T>>(data, _options);
        //    return values;
        //}
    }
}
