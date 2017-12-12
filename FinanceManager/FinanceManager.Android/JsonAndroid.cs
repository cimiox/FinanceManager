using Android.Content;
using Android.Content.Res;
using FinanceManager.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(FinanceManager.Droid.JsonAndroid))]
namespace FinanceManager.Droid
{
    public class JsonAndroid : IFileWorker
    {
        public Task DeleteAsync(string filename)
        {
            File.Delete(GetFilePath(filename));
            return Task.FromResult(true);
        }

        public Task<bool> ExistsAsync(string filename)
        {
            string filepath = GetFilePath(filename);
            bool exists = File.Exists(filepath);

            return Task.FromResult(exists);
        }

        public Task<IEnumerable<string>> GetFilesAsync()
        {
            IEnumerable<string> filenames = from filepath in Directory.EnumerateFiles(GetDocsPath())
                                            select Path.GetFileName(filepath);
            return Task.FromResult(filenames);
        }

        public async Task<string> LoadTextAsync(string filename)
        {
            string filepath = GetFilePath(filename);
            string text;
            using (StreamReader reader = File.OpenText(filepath))
            {
                text = await reader.ReadToEndAsync();
            }

            if (string.IsNullOrEmpty(text))
            {
                using (StreamReader readerAssets = new StreamReader(Forms.Context.Assets.Open(filename)))
                {
                    await SaveTextAsync(filename, await readerAssets.ReadToEndAsync());
                    return await readerAssets.ReadToEndAsync();
                }
            }

            return text;
        }

        public async Task SaveTextAsync(string filename, string text)
        {
            string filepath = GetFilePath(filename);
            using (StreamWriter writer = File.CreateText(filepath))
            {
                await writer.WriteAsync(text);
            }
        }

        private string GetFilePath(string filename)
        {
            return Path.Combine(GetDocsPath(), filename);
        }

        private string GetDocsPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }
    }
}